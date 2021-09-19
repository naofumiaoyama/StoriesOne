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
            var sheetComment = storiesBook.GetSheet("Comments");
            var sheetChapter = storiesBook.GetSheet("Chapters");
            var sheetFriendRelationship = storiesBook.GetSheet("FriendRelationships");
            var sheetGenre = storiesBook.GetSheet("Genres");
            var sheetStory = storiesBook.GetSheet("Stories");
            var sheetPost = storiesBook.GetSheet("Posts");
            var sheetPersonalInfo = storiesBook.GetSheet("PersonalInfos");
            var sheetReactionMark = storiesBook.GetSheet("ReactionMarks");
            var sheetPicture = storiesBook.GetSheet("Pictures");
            var sheetCharacter = storiesBook.GetSheet("Characters");
            var sheetNotification = storiesBook.GetSheet("Notifications");

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

                GenericRepository<Genre> genreRepository = new GenericRepository<Genre>(context);
                var lstgenres = GetTableDictionary(sheetGenre);
                foreach (var dicGenre in lstgenres)
                {
                    var genre = SetGenreEntity(dicGenre);
                    var getGenre = await genreRepository.Get(genre.Id);
                    if (getGenre == null)
                    {
                        await genreRepository.Add(genre);
                    }
                    else
                    {
                        var genreConfig = new MapperConfiguration(cfg => cfg.CreateMap<Genre, Genre>());
                        var genreMapper = new Mapper(genreConfig);
                        genreMapper.Map<Genre, Genre>(genre, getGenre);
                        await genreRepository.Update(getGenre);
                    }
                }

                GenericRepository<Story> storyRepository = new GenericRepository<Story>(context);
                var lstStory = GetTableDictionary(sheetStory);
                foreach(var dicStory in lstStory)
                {
                    var story = SetStoryEntity(dicStory);
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


                GenericRepository<Chapter> chapterRepository = new GenericRepository<Chapter>(context);
                var lstChapters = GetTableDictionary(sheetChapter);
                foreach(var dichapter in lstChapters)
                {
                    var chapter = SetChapterEntity(dichapter);
                    var getChapter = await chapterRepository.Get(chapter.Id);
                    if (getChapter == null)
                    {
                        await chapterRepository.Add(chapter);
                    }
                    else
                    {
                        var bodyConfig = new MapperConfiguration(cfg => cfg.CreateMap<Chapter, Chapter>());
                        var bodyMapper = new Mapper(bodyConfig);
                        bodyMapper.Map<Chapter, Chapter>(chapter, getChapter);
                        await chapterRepository.Update(getChapter);
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

                GenericRepository<ReactionMark> reactionMarkRepository = new GenericRepository<ReactionMark>(context);
                var lstReactionMarks = GetTableDictionary(sheetReactionMark);
                foreach (var dicReactionMark in lstReactionMarks)
                {
                    var reactionMark = SetReactionMarkEntity(dicReactionMark);
                    var getReactionMark = await reactionMarkRepository.Get(reactionMark.Id);
                    if (getReactionMark == null)
                    {
                        await reactionMarkRepository.Add(reactionMark);
                    }
                    else
                    {
                        var reactionMarkConfig = new MapperConfiguration(cfg => cfg.CreateMap<ReactionMark, ReactionMark>());
                        var reactionMarkMapper = new Mapper(reactionMarkConfig);
                        reactionMarkMapper.Map<ReactionMark, ReactionMark>(reactionMark, getReactionMark);
                        await reactionMarkRepository.Update(getReactionMark);
                    }
                }

                GenericRepository<Picture> pictureRepository = new GenericRepository<Picture>(context);
                var lstPictures = GetTableDictionary(sheetPicture);
                foreach (var dicPicture in lstPictures)
                {
                    var picture = SetPictureEntity(dicPicture);
                    var getPicture = await pictureRepository.Get(picture.Id);
                    if (getPicture == null)
                    {
                        await pictureRepository.Add(picture);
                    }
                    else
                    {
                        var pictureConfig = new MapperConfiguration(cfg => cfg.CreateMap<Picture, Picture>());
                        var pictureMapper = new Mapper(pictureConfig);
                        pictureMapper.Map<Picture, Picture>(picture, getPicture);
                        await pictureRepository.Update(getPicture);
                    }
                }

                GenericRepository<Character> characterRepository = new GenericRepository<Character>(context);
                var lstCharacters = GetTableDictionary(sheetCharacter);
                foreach (var dicCharacter in lstCharacters)
                {
                    var character = SetCharacterEntity(dicCharacter);
                    var getCharacter = await characterRepository.Get(character.Id);
                    if (getCharacter == null)
                    {
                        await characterRepository.Add(character);
                    }
                    else
                    {
                        var characterConfig = new MapperConfiguration(cfg => cfg.CreateMap<Character, Character>());
                        var characterMapper = new Mapper(characterConfig);
                        characterMapper.Map<Character, Character>(character, getCharacter);
                        await characterRepository.Update(getCharacter);
                    }
                }

                GenericRepository<Notification> notificationRepository = new GenericRepository<Notification>(context);
                var lstnotifications = GetTableDictionary(sheetNotification);
                foreach (var dicNotification in lstnotifications)
                {
                    var notification = SetNotificationEntity(dicNotification);
                    var getNotification = await notificationRepository.Get(notification.Id);
                    if (getNotification == null)
                    {
                        await notificationRepository.Add(notification);
                    }
                    else
                    {
                        var notificationConfig = new MapperConfiguration(cfg => cfg.CreateMap<Notification, Notification>());
                        var notificationMapper = new Mapper(notificationConfig);
                        notificationMapper.Map<Notification, Notification>(notification, getNotification);
                        await notificationRepository.Update(getNotification);
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
            person.NickName = dic[2].GetStringValue();
            person.LastName = dic[3].GetStringValue();
            person.DisplayName = dic[4].GetStringValue();
            person.SelfIntroduction = dic[5].GetStringValue();
            person.LivingPlace = dic[6].GetStringValue();
            person.Occupation = dic[7].GetStringValue();
            person.PersonType = (PersonType)dic[8].GetIntValue();
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
            address.PostalCode = dic[1].GetStringValue();
            address.CountryCode = (CountryCode)dic[2].GetIntValue();
            address.CountryName = dic[3].GetStringValue();
            address.PrefectureName = dic[4].GetStringValue();
            address.StateName = dic[5].GetStringValue();
            address.CityName = dic[6].GetStringValue();
            address.TownName = dic[7].GetStringValue();
            address.Street = dic[8].GetStringValue();
            address.Others = dic[9].GetStringValue();
            address.CreateUserId = dic[10].GetGuidValue();
            address.CreateDate = dic[11].GetDateTimeValue();
            address.UpdateUserId = dic[12].GetGuidValue();
            address.UpdateDate = dic[13].GetDateTimeValue();

            return address;
        }

        private Genre SetGenreEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Genre genre = new Genre();

            genre.Id = dic[0].GetGuidValue();
            genre.Name = dic[1].GetStringValue();
            genre.GenreType = (GenreType)dic[2].GetIntValue();
            genre.CreateUserId = dic[3].GetGuidValue();
            genre.CreateDate = dic[4].GetDateTimeValue();
            genre.UpdateUserId = dic[5].GetGuidValue();
            genre.UpdateDate = dic[6].GetDateTimeValue();

            return genre;
        }

        private Story SetStoryEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Story story = new Story();

            story.Id = dic[0].GetGuidValue();
            story.PersonId = dic[1].GetGuidValue();
            story.StoryType = (StoryType)dic[2].GetIntValue();
            story.Title = dic[3].GetStringValue();
            story.Summary = dic[4].GetStringValue();
            story.Thoughts = dic[5].GetStringValue();
            story.GenreId = dic[6].GetGuidValue();
            story.CreateUserId = dic[7].GetGuidValue();
            story.CreateDate = dic[8].GetDateTimeValue();
            story.UpdateUserId = dic[9].GetGuidValue();
            story.UpdateDate = dic[10].GetDateTimeValue();

            return story;
        }

        private Post SetPostEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Post post = new Post();

            post.Id = dic[0].GetGuidValue();
            post.StoryId = dic[1].GetGuidValue();
            post.Title = dic[2].GetStringValue();
            post.PostDateTime = dic[3].GetDateTimeValue();
            post.CreateUserId = dic[4].GetGuidValue();
            post.CreateDate = dic[5].GetDateTimeValue();
            post.UpdateUserId = dic[6].GetGuidValue();
            post.UpdateDate = dic[7].GetDateTimeValue();

            return post;
        }

        private Comment SetCommentEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Comment comment = new Comment();

            comment.Id = dic[0].GetGuidValue();
            comment.PostId = dic[1].GetGuidValue();
            comment.CommentText = dic[2].GetStringValue();
            comment.PostTime = dic[3].GetDateTimeValue();
            comment.CreateUserId = dic[4].GetGuidValue();
            comment.CreateDate = dic[5].GetDateTimeValue();
            comment.UpdateUserId = dic[6].GetGuidValue();
            comment.UpdateDate = dic[7].GetDateTimeValue();

            return comment;
        }

        private Chapter SetChapterEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Chapter chapter = new Chapter();

            chapter.Id = dic[0].GetGuidValue();
            chapter.StoryId = dic[1].GetGuidValue();
            chapter.Number = dic[2].GetIntValue();
            chapter.Title = dic[3].GetStringValue();
            chapter.Content = dic[4].GetStringValue();
            chapter.CreateUserId = dic[5].GetGuidValue();
            chapter.CreateDate = dic[6].GetDateTimeValue();
            chapter.UpdateUserId = dic[7].GetGuidValue();
            chapter.UpdateDate = dic[8].GetDateTimeValue();

            return chapter;
        }



        private FriendRelationship SetFriendRelationashipEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.FriendRelationship friendRelationship = new FriendRelationship();

            friendRelationship.Id = dic[0].GetGuidValue();
            friendRelationship.PersonId = dic[1].GetGuidValue();
            friendRelationship.FullName = dic[2].GetStringValue();
            friendRelationship.FriendPersonId = dic[3].GetGuidValue();
            friendRelationship.FriendFullName = dic[4].GetStringValue();
            friendRelationship.FriendshipDateTime = dic[5].GetDateTimeValue();
            friendRelationship.CreateUserId = dic[6].GetGuidValue();
            friendRelationship.CreateDate = dic[7].GetDateTimeValue();
            friendRelationship.UpdateUserId = dic[8].GetGuidValue();
            friendRelationship.UpdateDate = dic[9].GetDateTimeValue();

            return friendRelationship;
        }


        private PersonalInfo SetPersonalInfoEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.PersonalInfo personalInfo = new PersonalInfo();

            personalInfo.Id = dic[0].GetGuidValue();
            personalInfo.PersonId = dic[1].GetGuidValue();
            personalInfo.LoginId = dic[2].GetStringValue();
            personalInfo.EncryptedPassword = dic[3].GetStringValue();
            personalInfo.Token = dic[4].GetStringValue();
            personalInfo.MobileNumber = dic[5].GetStringValue();
            personalInfo.Sex = (SexEnum)dic[6].GetIntValue();
            personalInfo.Birthdate = dic[7].GetDateTimeValue();
            personalInfo.MaritalStatus = (MaritalStatusEnum)dic[8].GetIntValue();
            personalInfo.EmailAddress1 = dic[9].GetStringValue();
            personalInfo.EmailAddress2 = dic[10].GetStringValue();
            personalInfo.AddressId = dic[11].GetGuidValue();
            personalInfo.CreateUserId = dic[12].GetGuidValue();
            personalInfo.CreateDate = dic[13].GetDateTimeValue();
            personalInfo.UpdateUserId = dic[14].GetGuidValue();
            personalInfo.UpdateDate = dic[15].GetDateTimeValue();

            return personalInfo;
        }

        private ReactionMark SetReactionMarkEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.ReactionMark reactionMark = new ReactionMark();

            reactionMark.Id = dic[0].GetGuidValue();
            reactionMark.PostId = dic[1].GetGuidValue();
            reactionMark.Url = dic[2].GetStringValue();
            reactionMark.Name = dic[3].GetStringValue();
            reactionMark.Clicked = dic[4].GetBoolValue();
            reactionMark.CreateUserId = dic[5].GetGuidValue();
            reactionMark.CreateDate = dic[6].GetDateTimeValue();
            reactionMark.UpdateUserId = dic[7].GetGuidValue();
            reactionMark.UpdateDate = dic[8].GetDateTimeValue();

            return reactionMark;
        }

        private Picture SetPictureEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Picture picture = new Picture();

            picture.Id = dic[0].GetGuidValue();
            picture.OwnerId = dic[1].GetGuidValue();
            picture.PictureOwnerType = (PictureOwnerType)dic[2].GetIntValue();
            picture.Url = dic[3].GetStringValue();
            picture.CreateUserId = dic[4].GetGuidValue();
            picture.CreateDate = dic[5].GetDateTimeValue();
            picture.UpdateUserId = dic[6].GetGuidValue();
            picture.UpdateDate = dic[7].GetDateTimeValue();

            return picture;
        }

        private Character SetCharacterEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Character character = new Character();

            character.Id = dic[0].GetGuidValue();
            character.StoryId = dic[1].GetGuidValue();
            character.Name = dic[2].GetStringValue();
            character.Description = dic[3].GetStringValue();
            character.CreateUserId = dic[4].GetGuidValue();
            character.CreateDate = dic[5].GetDateTimeValue();
            character.UpdateUserId = dic[6].GetGuidValue();
            character.UpdateDate = dic[7].GetDateTimeValue();

            return character;
        }

        private Notification SetNotificationEntity(Dictionary<int, CellValueInfo> dic)
        {
            Data.Entities.Notification notification = new Notification();
            Picture picture = new Picture();
            picture.Id = Guid.NewGuid();
            picture.PictureOwnerType = PictureOwnerType.Person;
            picture.Url = "Https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.forkknifeswoon.com%2Fwp-content%2Fuploads%2F2014%2F10%2Fsimple-homemade-chicken-ramen-fork-knife-swoon-01.jpg&imgrefurl=https%3A%2F%2Fwww.forkknifeswoon.com%2Fsimple-homemade-chicken-ramen%2F&tbnid=xvuanwzsBotXAM&vet=12ahUKEwi0q92A1t_yAhVK95QKHfbIAT4QMygBegUIARDfAQ..i&docid=Pt4KygPKLwIZ3M&w=690&h=862&itg=1&q=ramen%20pic&ved=2ahUKEwi0q92A1t_yAhVK95QKHfbIAT4QMygBegUIARDfAQ";
            
            notification.Id = dic[0].GetGuidValue();
            notification.DispImage = picture;
            notification.Contents = dic[2].GetStringValue();
            notification.UrlLink = dic[3].GetStringValue();
            notification.CreateUserId = dic[4].GetGuidValue();
            notification.CreateDate = dic[5].GetDateTimeValue();
            notification.UpdateUserId = dic[6].GetGuidValue();
            notification.UpdateDate = dic[7].GetDateTimeValue();

            return notification;
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

            public bool GetBoolValue()
            {
                return Convert.ToBoolean(Value);
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
