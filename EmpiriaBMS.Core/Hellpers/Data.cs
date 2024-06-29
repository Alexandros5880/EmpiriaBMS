using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Models.Models;
using Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text;


namespace EmpiriaBMS.Core.Hellpers;

public static class Data
{
    private static string _seperator = "  ,  ";

    private static LoggerManager _logger;
    public static LoggerManager Logger => _logger;

    public static void InitializeLogger(ILogger<LoggerManager> logger, string projectName) =>
        _logger = new LoggerManager(logger, projectName);

    #region Get CSV String Content From Data
    public static string GetCsvContent<T>(IList<T> data)
    {
        var content = SCV.GenerateCsvContent(data);

        return content;
    }

    public static string GenerateCsvContentDynamic(List<object> dataList, Type itemType)
    {
        MethodInfo method = typeof(Data).GetMethod("GetCsvContent", BindingFlags.Public | BindingFlags.Static);
        if (method == null)
            throw new InvalidOperationException("The method GetCsvContent could not be found.");

        // Make the method generic with the specified item type
        MethodInfo genericMethod = method.MakeGenericMethod(itemType);

        // Invoke the generic method and get the result
        Array array = Array.CreateInstance(itemType, dataList.Count);
        for (int i = 0; i < dataList.Count; i++)
        {
            array.SetValue(dataList[i], i);
        }

        // Invoke the generic method and get the result
        var result = genericMethod.Invoke(null, new object[] { array });

        return (string)result;
    }
    #endregion

    public static void ExportData<T>(string filePath, IList<T> data, FileType fileType = FileType.CSV)
    {
        switch (fileType)
        {
            case FileType.CSV:
                var csvContent = SCV.GenerateCsvContent(data);
                SCV.SaveCsvToFile(csvContent, filePath);
                break;

            default:
                break;
        }
    }

    public static async Task<List<T>> ImportData<T>(Stream stream, FileType fileType = FileType.CSV)
    {
        switch (fileType)
        {
            case FileType.CSV:
                return await SCV.ImportFromCsv<T>(stream);

            default:
                return null;
        }
    }

    public static Type GetListItemType(List<object> dataList)
    {
        foreach (var item in dataList)
        {
            if (item != null)
            {
                return item.GetType();
            }
        }

        return null;
    }

    #region Add / Update / Delete Records
    public static async Task<bool> UpsertAsync(AppDbContext appDbContext, object item)
    {
        try
        {
            Type type = item.GetType();

            return await Upsert(appDbContext, item, type);

            //switch (type)
            //{
            //    case var t when t == typeof(Address):
            //        return await Upsert(appDbContext, item as Address);
            //    case var t when t == typeof(Client):
            //        return await Upsert<Client>(appDbContext, item as Client);
            //    case var t when t == typeof(Contract):
            //        return await Upsert<Contract>(appDbContext, item as Contract);
            //    case var t when t == typeof(DailyTime):
            //        return await Upsert<DailyTime>(appDbContext, item as DailyTime);
            //    case var t when t == typeof(Deliverable):
            //        return await Upsert<Deliverable>(appDbContext, item as Deliverable);
            //    case var t when t == typeof(DeliverableEmployee):
            //        return await Upsert<DeliverableEmployee>(appDbContext, item as DeliverableEmployee);
            //    case var t when t == typeof(DeliverableType):
            //        return await Upsert<DeliverableType>(appDbContext, item as DeliverableType);
            //    case var t when t == typeof(Discipline):
            //        return await Upsert<Discipline>(appDbContext, item as Discipline);
            //    case var t when t == typeof(DisciplineEngineer):
            //        return await Upsert<DisciplineEngineer>(appDbContext, item as DisciplineEngineer);
            //    case var t when t == typeof(DisciplineType):
            //        return await Upsert<DisciplineType>(appDbContext, item as DisciplineType);
            //    case var t when t == typeof(Document):
            //        return await Upsert<Document>(appDbContext, item as Document);
            //    case var t when t == typeof(Email):
            //        return await Upsert<Email>(appDbContext, item as Email);
            //    case var t when t == typeof(Invoice):
            //        return await Upsert<Invoice>(appDbContext, item as Invoice);
            //    case var t when t == typeof(InvoiceType):
            //        return await Upsert<InvoiceType>(appDbContext, item as InvoiceType);
            //    case var t when t == typeof(Issue):
            //        return await Upsert<Issue>(appDbContext, item as Issue);
            //    case var t when t == typeof(Led):
            //        return await Upsert<Led>(appDbContext, item as Led);
            //    case var t when t == typeof(Offer):
            //        return await Upsert<Offer>(appDbContext, item as Offer);
            //    case var t when t == typeof(OfferState):
            //        return await Upsert<OfferState>(appDbContext, item as OfferState);
            //    case var t when t == typeof(OfferType):
            //        return await Upsert<OfferType>(appDbContext, item as OfferType);
            //    case var t when t == typeof(Payment):
            //        return await Upsert<Payment>(appDbContext, item as Payment);
            //    case var t when t == typeof(PaymentType):
            //        return await Upsert<PaymentType>(appDbContext, item as PaymentType);
            //    case var t when t == typeof(Permission):
            //        return await Upsert<Permission>(appDbContext, item as Permission);
            //    case var t when t == typeof(Project):
            //        return await Upsert<Project>(appDbContext, item as Project);
            //    case var t when t == typeof(ProjectCategory):
            //        return await Upsert<ProjectCategory>(appDbContext, item as ProjectCategory);
            //    case var t when t == typeof(Projection):
            //        return await Upsert<Projection>(appDbContext, item as Projection);
            //    case var t when t == typeof(ProjectStage):
            //        return await Upsert<ProjectStage>(appDbContext, item as ProjectStage);
            //    case var t when t == typeof(ProjectSubCategory):
            //        return await Upsert<ProjectSubCategory>(appDbContext, item as ProjectSubCategory);
            //    case var t when t == typeof(ProjectSubConstructor):
            //        return await Upsert<ProjectSubConstructor>(appDbContext, item as ProjectSubConstructor);
            //    case var t when t == typeof(Role):
            //        return await Upsert<Role>(appDbContext, item as Role);
            //    case var t when t == typeof(RolePermission):
            //        return await Upsert<RolePermission>(appDbContext, item as RolePermission);
            //    case var t when t == typeof(SupportiveWork):
            //        return await Upsert<SupportiveWork>(appDbContext, item as SupportiveWork);
            //    case var t when t == typeof(SupportiveWorkEmployee):
            //        return await Upsert<SupportiveWorkEmployee>(appDbContext, item as SupportiveWorkEmployee);
            //    case var t when t == typeof(SupportiveWorkType):
            //        return await Upsert<SupportiveWorkType>(appDbContext, item as SupportiveWorkType);
            //    case var t when t == typeof(TeamsRequestedUser):
            //        return await Upsert<TeamsRequestedUser>(appDbContext, item as TeamsRequestedUser);
            //    case var t when t == typeof(Timespan):
            //        return await Upsert<Timespan>(appDbContext, item as Timespan);
            //    case var t when t == typeof(User):
            //        return await Upsert<User>(appDbContext, item as User);
            //    case var t when t == typeof(UserRole):
            //        return await Upsert<UserRole>(appDbContext, item as UserRole);
            //    default:
            //        return false;
            //}

            //// Get the Set<T> method from DbContext
            //MethodInfo setMethod = typeof(AppDbContext).GetMethod("Set", Type.EmptyTypes).MakeGenericMethod(type);

            //// Invoke the Set<T> method to get the DbSet<T>
            //object dbSet = setMethod.Invoke(appDbContext, null);

            //// Get the AddAsync method from DbSet<T>
            //MethodInfo addAsyncMethod = typeof(DbSet<>).MakeGenericType(type).GetMethod("AddAsync", new[] { type, typeof(CancellationToken) });

            //if (addAsyncMethod != null)
            //{
            //    // Invoke the AddAsync method with a CancellationToken.None
            //    var valueTask = (dynamic)addAsyncMethod.Invoke(dbSet, new object[] { item, CancellationToken.None });
            //    await valueTask?.AsTask();
            //    appDbContext.Entry(item).State = EntityState.Added;
            //    return true;
            //}
            //else
            //    return false;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception Data.AddAsync(): {ex.Message}, \n Inner Exception: {ex.InnerException}");

            return false;
        }
    }

    public static async Task<bool> Upsert(AppDbContext appDbContext, object item, Type type)
    {
        // Get the generic method definition for Upsert<T>
        MethodInfo method = typeof(Data).GetMethods()
                                        .Where(m => m.Name == nameof(Upsert) && m.IsGenericMethodDefinition)
                                        .FirstOrDefault();

        if (method == null)
            throw new InvalidOperationException("Could not find the generic method 'Upsert'.");

        // Make the generic method for the specific type
        MethodInfo genericMethod = method.MakeGenericMethod(type);

        // Invoke the generic method
        var valueTask = (Task<bool>)genericMethod.Invoke(null, new object[] { appDbContext, item });

        // Await the task and return the result
        return await valueTask;
    }

    public static async Task<bool> Upsert<T>(AppDbContext appDbContext, T item)
        where T : class, IEntity
    {
        try
        {
            T result;
            if (item != null && !appDbContext.Set<T>().Any(o => o.Id == item.Id))
            {
                result = (await appDbContext.Set<T>().AddAsync(item))?.Entity;
            }
            else
            {
                result = await appDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == item.Id);
                if (result != null)
                    appDbContext.Entry(item).CurrentValues.SetValues(Mapping.Mapper.Map<T>(item));
            }
            return result != null;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception Data.Upsert<{nameof(T)}>(): {ex.Message}, \n Inner Exception: {ex.InnerException}");

            return false;
        }
    }
    #endregion

    private static class SCV
    {
        public static string GenerateCsvContent<T>(IList<T> data)
        {
            var properties = typeof(T).GetProperties();
            var csvBuilder = new StringBuilder();


            // Add Columns
            var columnValues = new List<string>();
            foreach (var prop in properties)
            {
                bool isPrimitiveOrString = prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string);
                bool isNotIEntity = !typeof(IEntity).IsAssignableFrom(prop.PropertyType);
                bool isCollection = prop.PropertyType.IsGenericType &&
                                    (prop.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>) ||
                                     prop.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) ||
                                     prop.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) ||
                                     prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>));

                if (isNotIEntity && !isCollection)
                    columnValues.Add(prop.Name);

            }
            csvBuilder.AppendLine(string.Join(_seperator, columnValues));


            // Add Values
            foreach (var item in data)
            {
                var lineValues = new List<string>();

                foreach (var prop in properties)
                {
                    bool isPrimitiveOrString = prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string);
                    bool isNotIEntity = !typeof(IEntity).IsAssignableFrom(prop.PropertyType);
                    bool isCollection = prop.PropertyType.IsGenericType &&
                                    (prop.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>) ||
                                     prop.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) ||
                                     prop.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) ||
                                     prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>));

                    if (isNotIEntity && !isCollection)
                    {
                        var propValue = prop.GetValue(item);
                        lineValues.Add(propValue?.ToString() ?? "");
                    }

                }

                csvBuilder.AppendLine(string.Join(_seperator, lineValues));
            }

            return csvBuilder.ToString();
        }

        public static void SaveCsvToFile(string csvContent, string filePath)
        {
            File.WriteAllText(filePath, csvContent);
        }

        public static async Task<List<T>> ImportFromCsv<T>(Stream stream)
        {
            try
            {
                using (StreamReader reader = new StreamReader(stream))
                {

                    List<string> columns = new List<string>();
                    List<List<string>> rows = new List<List<string>>();

                    string line;
                    int count = 0;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (count == 0)
                        {
                            columns = new List<string>(line.Split(_seperator));
                        }
                        else
                        {
                            var row = new List<string>(line.Split(_seperator));
                            if (row.Count > 1)
                                rows.Add(row);
                        }
                        count++;
                    }

                    // Create Instance
                    PropertyInfo[] properties = typeof(T).GetProperties();
                    List<T> data = new List<T>();

                    foreach (var row in rows)
                    {
                        if (row == null || row.Count == 0)
                            continue;
                        var column = 0;
                        T instance = Activator.CreateInstance<T>();
                        foreach (var val in row)
                        {
                            _setProperty(instance, columns[column], val);
                            column++;
                        }
                        data.Add(instance);
                    }

                    return data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception Data.ImportFromCsv(): {ex.Message}, \n Inner Exception: {ex.InnerException}");

                return null;
            }
        }
    }

    private static void _setProperty<T>(T instance, string propertyName, string propertyValue)
    {
        if (string.IsNullOrEmpty(propertyValue) || string.IsNullOrEmpty(propertyName))
            return;

        try
        {
            PropertyInfo property = typeof(T).GetProperty(propertyName);

            if (property != null && property.CanWrite)
            {
                Type propertyType = property.PropertyType;

                // DateTime
                bool isDateTime = _isDateTimeOrNullableDateTime(propertyType);
                if (isDateTime)
                {
                    DateTime dateTime;
                    if (DateTime.TryParse(propertyValue, out dateTime))
                        property.SetValue(instance, dateTime);
                }
                else
                {
                    // Int
                    if (propertyType == typeof(int?) && int.TryParse(propertyValue, out int intValue))
                    {
                        property.SetValue(instance, intValue);
                    }

                    // Double
                    else if (propertyType == typeof(double?) && double.TryParse(propertyValue, out double doubleValue))
                    {
                        property.SetValue(instance, doubleValue);
                    }

                    // Enum
                    else if (propertyType.IsEnum)
                    {
                        try
                        {
                            object enumValue = null;
                            enumValue = Enum.Parse(propertyType, propertyValue);
                            property.SetValue(instance, enumValue);
                        }
                        catch (ArgumentException aex)
                        {
                            // TODO: Log Exception
                            Console.WriteLine($"\n\nException Data._setProperty.Try_Parse_Enum: {aex.Message}, \nInner: {aex.InnerException?.Message}");
                        }
                    }

                    // Other
                    else
                    {
                        object value = Convert.ChangeType(propertyValue, propertyType);
                        property.SetValue(instance, value);
                    }

                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception Data._setProperty(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    private static bool _isDateTimeOrNullableDateTime(Type propertyType) =>
    propertyType == typeof(DateTime) ||
           (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
            propertyType.GetGenericArguments()[0] == typeof(DateTime));
}

public enum FileType
{
    CSV
}
