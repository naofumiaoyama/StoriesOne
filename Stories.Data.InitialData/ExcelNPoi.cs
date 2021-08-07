using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using System.Data.SqlClient;
using Dapper;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Reflection;
using NPOI.SS.Formula.Functions;
using System.Data;
using Stories.Data.Repositories;
using Stories.Data.Entities;

namespace Stories.Data.InitialData
{
    public class ExcelNPoi
    {

        List<TableColumnField> dataList = new List<TableColumnField>();

        public void PutColumnInfoFromSQLServer()
        {
            string filePath = @"../../../ExcelFiles/StoriesData-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            try
            {
                var book = CreateNewBook(filePath);

                DatabaseContext databaseContext = new DatabaseContext();
                Type type = databaseContext.GetType();
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var tables = properties.Where(p => p.PropertyType.Name == "DbSet`1");

                foreach (PropertyInfo p in tables)
                {
                    book.CreateSheet(p.Name);
                }
                foreach (PropertyInfo p in tables)
                {
                    var tableColumnFields = GetTableColumnInfo(p.Name).Result;
                    var sheet = book.GetSheet(p.Name);
                    int i = 0;
                    foreach (var field in tableColumnFields)
                    {
                        WriteCell(sheet, i, 0, field.COLUMN_NAME);
                        i++;
                    }
                }
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    book.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public async Task ReadExcelBookToSQLServerAsync(string bookFileName)
        {
            string filePath = @"../../../ExcelFiles/" + bookFileName;

            // Get All Sheets Name
            XSSFWorkbook storiesBook;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                storiesBook = new XSSFWorkbook(fs);

                List<string> sheetNamelst = new List<string>();

                for (int i = 0; i < storiesBook.NumberOfSheets; i++)
                {
                    sheetNamelst.Add(storiesBook.GetSheetName(i));
                }
            }

            // Read Data from the sheet
            var sheetPeople = storiesBook.GetSheet("People");
            var sheetAddress = storiesBook.GetSheet("Addresses");
            var sheetTimeline = storiesBook.GetSheet("Timelines");
            var sheetPost = storiesBook.GetSheet("Posts");

            using (var context = new DatabaseContext())
            {
                GenericRepository<Person> personRepository = new GenericRepository<Person>(context);
                var dicPeople = GetTableDictionary(sheetPeople);
                var person = SetPersonEntity(dicPeople);
                await personRepository.Add(person);

                GenericRepository<Entities.Address> addressRepository = new GenericRepository<Entities.Address>(context);
                var dicAddress = GetTableDictionary(sheetAddress);
                var address = SetAddress(dicAddress);
                await addressRepository.Add(address);

                GenericRepository<Timeline> timelineRepository = new GenericRepository<Timeline>(context);
                var dicTimelines = GetTableDictionary(sheetTimeline);
                var timeline = SetTimeLineEntity(dicTimelines);
                await timelineRepository.Add(timeline);

                GenericRepository<Post> postRepository = new GenericRepository<Post>(context);
                var dicPosts = GetTableDictionary(sheetPost);
                var post = SetPostEntity(dicPosts);
                await postRepository.Add(post);
            }
            
        }

        

        // Put Data to SQLServer by Repository


        private Dictionary<int, CellValueInfo> GetTableDictionary(ISheet sheet)
        {
            Dictionary<int, CellValueInfo> dic = null;
            int lastRowNum = sheet.LastRowNum;
            // Get Data
            for (int r = 1; r < lastRowNum; r++)
            {
                dic = new Dictionary<int, CellValueInfo>();
                var datarow = sheet.GetRow(r);
                {
                    foreach (var cell in datarow.Cells)
                    {
                        switch (cell.CellType)
                        {
                            case CellType.Blank: break;
                            case CellType.Boolean:
                                var valueBool = cell.BooleanCellValue;
                                AddDataDic(dic, cell.ColumnIndex, valueBool.GetType(), valueBool.ToString());
                                break;
                            case CellType.String:
                                var valueString = cell.StringCellValue;
                                AddDataDic(dic, cell.ColumnIndex, valueString.GetType(), valueString.ToString());
                                break;
                            case CellType.Numeric:

                                if (DateUtil.IsCellDateFormatted(cell))
                                {
                                    var valueDate = cell.DateCellValue.ToString("yyyy/MM/dd HH:mm:ss");
                                    AddDataDic(dic, cell.ColumnIndex, valueDate.GetType(), valueDate.ToString());
                                }
                                else
                                {
                                    var valueNumeric = cell.NumericCellValue;
                                    AddDataDic(dic, cell.ColumnIndex, valueNumeric.GetType(), valueNumeric.ToString());
                                }

                                break;
                        }
                    }
                }
            }
            return dic;
        }

        private Dictionary<int, CellValueInfo> AddDataDic(Dictionary<int, CellValueInfo> dic, int columIndex, System.Type type, string value)
        {
            CellValueInfo cellValueInfo = new CellValueInfo();
            cellValueInfo.ColumnIndex = columIndex;
            cellValueInfo.Value = value;
            dic.Add(columIndex, cellValueInfo);
            return dic;
        }
        
        private Person SetPersonEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Person person = new Entities.Person();

            person.Id = dic[0].GetGuidValue();
            person.FirstName = dic[1].GetStringValue();
            person.MiddleName = dic[2].GetStringValue();
            person.LastName = dic[3].GetStringValue();
            person.PersonType = (PersonType)dic[4].GetIntValue();
            person.DisplayName = dic[5].GetStringValue();
            person.SelfIntroduction = dic[6].GetStringValue();
            person.LivingPlace = dic[7].GetStringValue();
            person.Occupation = dic[8].GetStringValue();
            person.CreateUserId = dic[9].GetGuidValue();
            person.CreateDate = dic[10].GetDateTimeValue();
            person.UpdateUserId = dic[11].GetGuidValue();
            person.UpdateDate = dic[12].GetDateTimeValue();

            return person;
        }

        private Entities.Address SetAddress(Dictionary<int,CellValueInfo> dic)
        {
            Data.Entities.Address address = new Entities.Address();

            address.Id = dic[0].GetGuidValue();
            address.CountryCode = dic[1].GetStringValue();
            address.CountryName = dic[2].GetStringValue();
            address.PrefectureCode = dic[3].GetStringValue();
            address.PrefectureName = dic[4].GetStringValue();
            address.StateCode = dic[5].GetStringValue();
            address.StateName = dic[6].GetStringValue();
            address.CityName = dic[7].GetStringValue();
            address.TownName = dic[8].GetStringValue();
            address.Street = dic[9].GetStringValue();
            address.Others = dic[10].GetStringValue();
            address.CreateUserId = dic[11].GetGuidValue();
            address.CreateDate = dic[12].GetDateTimeValue();
            address.UpdateUserId = dic[13].GetGuidValue();
            address.UpdateDate = dic[14].GetDateTimeValue();

            return address;
        }

        private Timeline SetTimeLineEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Timeline timeline = new Timeline();

            timeline.Id = dic[0].GetGuidValue();
            timeline.OwnerPersonId = dic[1].GetGuidValue();
            timeline.TimelineName = dic[2].GetStringValue();
            timeline.CreateUserId = dic[3].GetGuidValue();
            timeline.CreateDate = (DateTime)dic[4].GetDateTimeValue();
            timeline.UpdateUserId = dic[5].GetGuidValue();
            timeline.UpdateDate = (DateTime)dic[6].GetDateTimeValue();

            return timeline;     
        }

        private Post SetPostEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Post post = new Post();

            post.Id = dic[0].GetGuidValue();
            post.TimelineId = dic[1].GetGuidValue();
            post.Title = dic[2].GetStringValue();
            post.PostDateTime = (DateTime)dic[3].GetDateTimeValue();
            post.CreateUserId = dic[4].GetGuidValue();
            post.CreateDate = (DateTime)dic[5].GetDateTimeValue();
            post.UpdateUserId = dic[6].GetGuidValue();
            post.UpdateDate = (DateTime)dic[7].GetDateTimeValue();

            return post;
        }

        
        public class CellValueInfo
        {
            public int ColumnIndex { get; set; }
            public string Value { get; set; }

            public Guid GetGuidValue()
            {
                return Guid.Parse(Value);
            }
            public string GetStringValue()
            {
                return Value;
            }
            public int GetIntValue()
            {
                return Convert.ToInt32(Value);
            }
            public double GetDoubleValue()
            {
                return Convert.ToDouble(Value);
            }

            public DateTime GetDateTimeValue()
            {
                return Convert.ToDateTime(Value);
            }
        }

        static IWorkbook CreateNewBook(string filePath)
        {
            IWorkbook book;
            var extension = Path.GetExtension(filePath);

            if (extension == ".xls")
            {
                book = new HSSFWorkbook();
            }
            else if (extension == ".xlsx")
            {
                book = new XSSFWorkbook();
            }
            else
            {
                throw new ApplicationException("CreateNewBook: invalid extension");
            }

            return book;
        }

        public async Task<IEnumerable<TableColumnField>> GetTableColumnInfo(string tableName)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS " +
                                "WHERE TABLE_NAME = '" + tableName + "'";

                var tableColumnFields = connection.Query<TableColumnField>(query);

                await connection.CloseAsync();

                return tableColumnFields;

            }
        }
        public static string GetCellValue(ISheet sheet, int idxColumn, int idxRow)
        {
            var row = sheet.GetRow(idxRow) ?? sheet.CreateRow(idxRow);
            var cell = row.GetCell(idxColumn) ?? row.CreateCell(idxColumn);
            string value;

            switch (cell.CellType)
            {
                case CellType.String:
                    value = cell.StringCellValue;
                    break;
                case CellType.Numeric:
                    value = cell.NumericCellValue.ToString();
                    break;
                case CellType.Boolean:
                    value = cell.BooleanCellValue.ToString();
                    break;
                default:
                    value = "Value";
                    break;
            }
            return value;
        }

        public static void WriteCell(ISheet sheet, int columnIndex, int rowIndex, string value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }


        public static void WriteCell(ISheet sheet, int columnIndex, int rowIndex, double value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }


        public static void WriteCell(ISheet sheet, int columnIndex, int rowIndex, DateTime value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }


        public static void WriteStyle(ISheet sheet, int columnIndex, int rowIndex, ICellStyle style)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.CellStyle = style;
        }
    }

  
    public class TableColumnField
{
        public string TABLE_CATALOG { get; set; }
        public string TABLE_SCHEMA { get; set; }
        public string TABLE_NAME { get; set; }
        public string COLUMN_NAME { get; set; }
        public string ORDINAL_POSITION { get; set; }
        public string COLUMN_DEFAULT { get; set; }
        public string IS_NULLABLE { get; set; }
        public string DATA_TYPE { get; set; }
        public string CHARACTER_MAXIMUM_LENGTH { get; set; }
        public string CHARACTER_OCTET_LENGTH { get; set; }
        public string NUMERIC_PRECISION { get; set; }
        public string NUMERIC_PRECISION_RADIX { get; set; }
        public string NUMERIC_SCALE { get; set; }
        public string DATETIME_PRECISION { get; set; }
        public string CHARACTER_SET_CATALOG { get; set; }
        public string CHARACTER_SET_SCHEMA { get; set; }
        public string CHARACTER_SET_NAME { get; set; }
        public string COLLATION_CATALOG { get; set; }
        public string COLLATION_SCHEMA { get; set; }
        public string COLLATION_NAME { get; set; }
        public string DOMAIN_CATALOG { get; set; }
        public string  DOMAIN_SCHEMA { get; set; }
        public string  DOMAIN_NAME { get; set; }
    }

}
