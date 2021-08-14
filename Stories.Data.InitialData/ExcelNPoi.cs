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
using System.Data;
using Stories.Data.Repositories;
using Stories.Data.Entities;
using AutoMapper;

namespace Stories.Data.InitialData
{
    public class ExcelNPoi
    {
        List<TableColumnField> dataList = new List<TableColumnField>();

        public void PutColumnInfoFromSQLServer(string bookName)
        {
            string filePath = @"../../../ExcelFiles/" + bookName;

            try
            {
                XSSFWorkbook storiesBook;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    storiesBook = new XSSFWorkbook(fs);
                }

                DatabaseContext databaseContext = new DatabaseContext();
                Type type = databaseContext.GetType();
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var tables = properties.Where(p => p.PropertyType.Name == "DbSet`1");

                foreach (PropertyInfo p in tables)
                {
                    var sheet = storiesBook.GetSheet(p.Name);
                    if( sheet == null)
                    {
                        storiesBook.CreateSheet(p.Name);
                    }
                }
                foreach (PropertyInfo p in tables)
                {
                    var tableColumnFields = GetTableColumnInfo(p.Name).Result;
                    var sheet = storiesBook.GetSheet(p.Name);
                    int i = 0;
                    foreach (var field in tableColumnFields)
                    {
                        WriteCell(sheet, i, 0, field.COLUMN_NAME);
                        i++;
                    }
                }
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    storiesBook.Write(fs);
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
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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
            var sheetComment = storiesBook.GetSheet("Comments");
            var sheetBody = storiesBook.GetSheet("Bodies");
            var sheetFriendRelationship = storiesBook.GetSheet("FriendRelationships");
            var sheetStory = storiesBook.GetSheet("Stories");
            var sheetPersonalInfo = storiesBook.GetSheet("PersonalInfos");

            using (var context = new DatabaseContext())
            {
                GenericRepository<Person> personRepository = new GenericRepository<Person>(context);
                var lstPeople = GetTableDictionary(sheetPeople);
                foreach (var dicPeople in lstPeople)
                {
                    var person = SetPersonEntity(dicPeople);
                    var getPerson = await personRepository.Get(person.Id);
                    if(getPerson == null)
                    {
                        await personRepository.Add(person);
                    }
                    else
                    {
                        var userConfig = new MapperConfiguration(cfg => cfg.CreateMap<Person, Person>());
                        var userMapper = new Mapper(userConfig);
                        userMapper.Map<Person,Person>(person,getPerson);
                        await personRepository.Update(getPerson);
                    }   
                }

                GenericRepository<PersonalInfo> personalInfoRepository = new GenericRepository<PersonalInfo>(context);
                var lstPersonalInfos = GetTableDictionary(sheetPersonalInfo);
                foreach (var dicPersonalInfos in lstPersonalInfos) 
                {
                    var personalInfo = SetPersonalInfoEntity(dicPersonalInfos);
                    var getPersonalInfo = await personalInfoRepository.Get(personalInfo.Id);
                    if (getPersonalInfo == null)
                    {
                        await personalInfoRepository.Add(personalInfo);
                    }
                    else
                    {
                        var personalInfoConfig = new MapperConfiguration(cfg => cfg.CreateMap<PersonalInfo, PersonalInfo>());
                        var personalInfoMapper = new Mapper(personalInfoConfig);
                        personalInfoMapper.Map<PersonalInfo, PersonalInfo>(personalInfo, getPersonalInfo);
                        await personalInfoRepository.Update(getPersonalInfo);
                    }
                }

                GenericRepository<Address> addressRepository = new GenericRepository<Address>(context);
                var lstAddress = GetTableDictionary(sheetAddress);
                foreach(var dicAddress in lstAddress)
                {
                    var address = SetAddress(dicAddress);
                    var getAddress = await addressRepository.Get(address.Id);
                    if (getAddress == null)
                    {
                        await addressRepository.Add(address);
                    }
                    else
                    {
                        var addressConfig = new MapperConfiguration(cfg => cfg.CreateMap<Address, Address>());
                        var addressMapper = new Mapper(addressConfig);
                        addressMapper.Map<Address, Address>(address, getAddress);
                        await addressRepository.Update(getAddress);
                    }
                } 

                GenericRepository<Timeline> timelineRepository = new GenericRepository<Timeline>(context);
                var lstTimeline = GetTableDictionary(sheetTimeline);
                foreach(var dicTimeline in lstTimeline)
                {
                    var timeline = SetTimeLine(dicTimeline);
                  var getTimeline =  await timelineRepository.Get(timeline.Id);
                    if (getTimeline == null)
                    {
                        await timelineRepository.Add(timeline);
                    }
                    else
                    {
                        var timelineConfig = new MapperConfiguration(cfg => cfg.CreateMap<Timeline, Timeline>());
                        var timelineMapper = new Mapper(timelineConfig);
                        timelineMapper.Map<Timeline, Timeline>(timeline, getTimeline);
                        await timelineRepository.Update(getTimeline);
                    }
                }


                GenericRepository<Post> postRepository = new GenericRepository<Post>(context);
                var lstPost = GetTableDictionary(sheetPost);
                foreach(var dicPost in lstPost )
                {
                    var post = SetPostEntity(dicPost);
                   var getPost =  await postRepository.Get(post.Id);
                    if (getPost == null)
                    {
                        
                        await postRepository.Add(post);
                    }
                    else
                    {
                        var postConfig = new MapperConfiguration(cfg => cfg.CreateMap<Post, Post>());
                        var postMapper = new Mapper(postConfig);
                        postMapper.Map<Post, Post>(post, getPost);
                        await postRepository.Update(getPost);
                    }
                }


                GenericRepository<Comment> commentRepository = new GenericRepository<Comment>(context);
                var lstComments = GetTableDictionary(sheetComment);
                foreach(var dicComment in lstComments)
                {
                    var comment = SetCommentEntity(dicComment);
                   var getComment = await commentRepository.Get(comment.Id);
                    if (getComment == null)
                    {
                        await commentRepository.Add(comment);
                    }
                    else
                    {
                        var commentConfig = new MapperConfiguration(cfg => cfg.CreateMap<Comment, Comment>());
                        var commentMapper = new Mapper(commentConfig);
                        commentMapper.Map<Comment, Comment>(comment, getComment);
                        await commentRepository.Update(getComment);
                    }
                }

                GenericRepository<Story> storyRepository = new GenericRepository<Story>(context);
                var lstStories = GetTableDictionary(sheetStory);
                foreach (var dicstory in lstStories)

                {
                    var story = SetStoryEntity(dicstory);
                    var getStory = await storyRepository.Get(story.Id);
                    if (getStory == null)
                    {
                        await storyRepository.Add(story);
                    }
                    else
                    {
                        var storyConfig = new MapperConfiguration(cfg => cfg.CreateMap<Story, Story>());
                        var storyMapper = new Mapper(storyConfig);
                        storyMapper.Map<Story, Story>(story, getStory);
                        await storyRepository.Update(getStory);
                    }
                }

                GenericRepository<Body> bodyRepository = new GenericRepository<Body>(context);
                var lstBodies = GetTableDictionary(sheetBody);
                foreach(var dicbody in lstBodies)
                {
                    var body = SetBodyEntity(dicbody);
                    var getBody = await bodyRepository.Get(body.Id);
                    if (getBody == null)
                    {
                        await bodyRepository.Add(body);
                    }
                    else
                    {
                        var bodyConfig = new MapperConfiguration(cfg => cfg.CreateMap<Body, Body>());
                        var bodyMapper = new Mapper(bodyConfig);
                        bodyMapper.Map<Body, Body>(body, getBody);
                        await bodyRepository.Update(getBody);
                    }
                }

                GenericRepository<FriendRelationship> friendRelationshipRepository = new GenericRepository<FriendRelationship>(context);
                var lstFriendRelationships = GetTableDictionary(sheetFriendRelationship);
                foreach(var dicfriendRelationship in lstFriendRelationships)
                {
                    var friendRelationship = SetFriendRelationashipEntity(dicfriendRelationship);
                    var getFriendRelationship = await friendRelationshipRepository.Get(friendRelationship.Id);
                    if(getFriendRelationship == null)
                    {
                        await friendRelationshipRepository.Add(friendRelationship);
                    }
                    else
                    {
                        var friendRelationshipConfig = new MapperConfiguration(cfg => cfg.CreateMap<FriendRelationship, FriendRelationship>());
                        var friendRelationshipMapper = new Mapper(friendRelationshipConfig);
                        friendRelationshipMapper.Map<FriendRelationship, FriendRelationship>(friendRelationship, getFriendRelationship);
                        await friendRelationshipRepository.Update(getFriendRelationship);
                    }
                }
            }
            
        }

        private List<Dictionary<int, CellValueInfo>> GetTableDictionary(ISheet sheet)
        {
            List<Dictionary<int, CellValueInfo>> lst = new List<Dictionary<int, CellValueInfo>>(); 
            int lastRowNum = sheet.LastRowNum;
            // Get Data
            for (int r = 1; r < lastRowNum+1; r++)
            {
                Dictionary<int, CellValueInfo> dic = new Dictionary<int, CellValueInfo>();
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

                lst.Add(dic);
            }

            return lst;
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

        private Timeline SetTimeLine(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Timeline timeline = new Timeline();

            timeline.Id = dic[0].GetGuidValue();
            timeline.PersonId = dic[1].GetGuidValue();
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

        private Comment SetCommentEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Comment comment = new Comment();

            comment.Id = dic[0].GetGuidValue();
            comment.PostId = dic[1].GetGuidValue();
            comment.CommentText = dic[3].GetStringValue();
            comment.PostTime = (DateTime)dic[4].GetDateTimeValue();
            comment.CreateUserId = dic[5].GetGuidValue();
            comment.CreateDate = (DateTime)dic[6].GetDateTimeValue();
            comment.UpdateUserId = dic[7].GetGuidValue();
            comment.UpdateDate = (DateTime)dic[8].GetDateTimeValue();

            return comment;
        }

        private Body SetBodyEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Body body = new Body();

            body.Id = dic[0].GetGuidValue();
            body.StoryId = dic[1].GetGuidValue();
            body.ChapterNumber = dic[2].GetIntValue();
            body.BodyContent = dic[3].GetStringValue();
            body.CreateUserId = dic[4].GetGuidValue();
            body.CreateDate = (DateTime)dic[5].GetDateTimeValue();
            body.UpdateUserId = dic[6].GetGuidValue();
            body.UpdateDate = (DateTime)dic[7].GetDateTimeValue();

            return body;
        }

        private FriendRelationship SetFriendRelationashipEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.FriendRelationship friendRelationship = new FriendRelationship();

            friendRelationship.Id = dic[0].GetGuidValue();
            friendRelationship.PersonId = dic[1].GetGuidValue();
            friendRelationship.FullName = dic[2].GetStringValue();
            friendRelationship.FriendPersonId = dic[3].GetGuidValue();
            friendRelationship.FriendFullName = dic[4].GetStringValue();
            friendRelationship.FriendshipDateTime = (DateTime)dic[5].GetDateTimeValue();
            friendRelationship.CreateUserId = dic[6].GetGuidValue();
            friendRelationship.CreateDate = (DateTime)dic[7].GetDateTimeValue();
            friendRelationship.UpdateUserId = dic[8].GetGuidValue();
            friendRelationship.UpdateDate = (DateTime)dic[9].GetDateTimeValue();

            return friendRelationship;
        }

        private Story SetStoryEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Story story = new Story();

            story.Id = dic[0].GetGuidValue();
            story.PersonId = dic[1].GetGuidValue();
            story.Title = dic[2].GetStringValue();
            story.Summary = dic[3].GetStringValue();
            story.CreateUserId = dic[4].GetGuidValue();
            story.CreateDate = (DateTime)dic[5].GetDateTimeValue();
            story.UpdateUserId = dic[6].GetGuidValue();
            story.UpdateDate = (DateTime)dic[7].GetDateTimeValue();

            return story;
        }

        private PersonalInfo SetPersonalInfoEntity(Dictionary<int, CellValueInfo> dic)
        
        {
            Data.Entities.PersonalInfo personalInfo = new PersonalInfo();

            personalInfo.Id = dic[0].GetGuidValue();
            personalInfo.PersonId = dic[1].GetGuidValue();
            personalInfo.LoginId = dic[2].GetStringValue();
            personalInfo.EncryptedPassword = dic[3].GetStringValue();
            personalInfo.MobileNumber = dic[4].GetStringValue();
            personalInfo.Sex = (SexEnum)dic[5].GetIntValue();
            personalInfo.Birthdate = (DateTime)dic[6].GetDateTimeValue();
            personalInfo.MaritalStatus = (MaritalStatusEnum)dic[7].GetIntValue();
            personalInfo.EmailAddress1 = dic[8].GetStringValue();
            personalInfo.EmailAddress2 = dic[9].GetStringValue();
            personalInfo.AddressId = dic[10].GetGuidValue();
            personalInfo.CreateUserId = dic[11].GetGuidValue();
            personalInfo.CreateDate = (DateTime)dic[12].GetDateTimeValue();
            personalInfo.UpdateUserId = dic[13].GetGuidValue();
            personalInfo.UpdateDate = (DateTime)dic[14].GetDateTimeValue();

            return personalInfo;
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
