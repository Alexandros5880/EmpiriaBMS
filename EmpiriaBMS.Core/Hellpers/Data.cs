using EmpiriaBMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;


namespace EmpiriaBMS.Core.Hellpers;

public static class Data
{
    private static string _seperator = "  ,  ";

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
    public static bool Add(AppDbContext AppDbContext, object item)
    {
        try
        {
            Type type = item.GetType();

            // Get the Set<T> method from DbContext
            MethodInfo setMethod = typeof(AppDbContext).GetMethod("Set", Type.EmptyTypes).MakeGenericMethod(type);

            // Invoke the Set<T> method to get the DbSet<T>
            object dbSet = setMethod.Invoke(AppDbContext, null);

            // Get the Add method from DbSet<T>
            MethodInfo addMethod = typeof(DbSet<>).MakeGenericType(type).GetMethod("Add", new[] { type });

            if (addMethod != null)
            {
                addMethod.Invoke(dbSet, new[] { item });
                AppDbContext.Entry(item).State = EntityState.Added;
                return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception Data.Add: {ex.Message}, \nInner: {ex.InnerException?.Message}");

            return false;
        }
    }

    public static async Task<bool> AddAsync(AppDbContext appDbContext, object item)
    {
        try
        {
            Type type = item.GetType();
            dynamic obj;
            dynamic result;

            switch (type)
            {
                case var t when t == typeof(Address):
                    obj = item as Address;
                    result = await appDbContext.Set<Address>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Client):
                    obj = item as Client;
                    result = await appDbContext.Set<Client>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Contract):
                    obj = item as Contract;
                    result = await appDbContext.Set<Contract>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(DailyTime):
                    obj = item as DailyTime;
                    result = await appDbContext.Set<DailyTime>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Deliverable):
                    obj = item as Deliverable;
                    result = await appDbContext.Set<Deliverable>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(DeliverableEmployee):
                    obj = item as DeliverableEmployee;
                    result = await appDbContext.Set<DeliverableEmployee>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(DeliverableType):
                    obj = item as DeliverableType;
                    result = await appDbContext.Set<DeliverableType>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Discipline):
                    obj = item as Discipline;
                    result = await appDbContext.Set<Discipline>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(DisciplineEngineer):
                    obj = item as DisciplineEngineer;
                    result = await appDbContext.Set<DisciplineEngineer>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(DisciplineType):
                    obj = item as DisciplineType;
                    result = await appDbContext.Set<DisciplineType>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Document):
                    obj = item as Document;
                    result = await appDbContext.Set<Document>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Email):
                    obj = item as Email;
                    result = await appDbContext.Set<Email>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Invoice):
                    obj = item as Invoice;
                    result = await appDbContext.Set<Invoice>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(InvoiceType):
                    obj = item as InvoiceType;
                    result = await appDbContext.Set<InvoiceType>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Issue):
                    obj = item as Issue;
                    result = await appDbContext.Set<Issue>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Led):
                    obj = item as Led;
                    result = await appDbContext.Set<Led>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Offer):
                    obj = item as Offer;
                    result = await appDbContext.Set<Offer>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(OfferState):
                    obj = item as OfferState;
                    result = await appDbContext.Set<OfferState>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(OfferType):
                    obj = item as OfferType;
                    result = await appDbContext.Set<OfferType>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Payment):
                    obj = item as Payment;
                    result = await appDbContext.Set<Payment>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(PaymentType):
                    obj = item as PaymentType;
                    result = await appDbContext.Set<PaymentType>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Permission):
                    obj = item as Permission;
                    result = await appDbContext.Set<Permission>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Project):
                    obj = item as Project;
                    result = await appDbContext.Set<Project>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(ProjectCategory):
                    obj = item as ProjectCategory;
                    result = await appDbContext.Set<ProjectCategory>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Projection):
                    obj = item as Projection;
                    result = await appDbContext.Set<Projection>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(ProjectStage):
                    obj = item as ProjectStage;
                    result = await appDbContext.Set<ProjectStage>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(ProjectSubCategory):
                    obj = item as ProjectSubCategory;
                    result = await appDbContext.Set<ProjectSubCategory>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(ProjectSubConstructor):
                    obj = item as ProjectSubConstructor;
                    result = await appDbContext.Set<ProjectSubConstructor>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Role):
                    obj = item as Role;
                    result = await appDbContext.Set<Role>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(RolePermission):
                    obj = item as RolePermission;
                    result = await appDbContext.Set<RolePermission>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(SupportiveWork):
                    obj = item as SupportiveWork;
                    result = await appDbContext.Set<SupportiveWork>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(SupportiveWorkEmployee):
                    obj = item as SupportiveWorkEmployee;
                    result = await appDbContext.Set<SupportiveWorkEmployee>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(SupportiveWorkType):
                    obj = item as SupportiveWorkType;
                    result = await appDbContext.Set<SupportiveWorkType>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(TeamsRequestedUser):
                    obj = item as TeamsRequestedUser;
                    result = await appDbContext.Set<TeamsRequestedUser>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(Timespan):
                    obj = item as Timespan;
                    result = await appDbContext.Set<Timespan>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(User):
                    obj = item as User;
                    result = await appDbContext.Set<User>().AddAsync(obj);
                    return result != null;
                case var t when t == typeof(UserRole):
                    obj = item as UserRole;
                    result = await appDbContext.Set<UserRole>().AddAsync(obj);
                    return result != null;
                default:
                    return false;
            }










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
            // TODO: Log Exception
            Console.WriteLine($"Exception Data.AddAsync: {ex.Message}, \nInner: {ex.InnerException?.Message}");

            return false;
        }
    }

    public static bool Update(AppDbContext appDbContext, object item)
    {
        try
        {
            Type type = item.GetType();

            // Get the Set<T> method from DbContext
            MethodInfo setMethod = typeof(AppDbContext).GetMethod("Set", Type.EmptyTypes).MakeGenericMethod(type);

            // Invoke the Set<T> method to get the DbSet<T>
            object dbSet = setMethod.Invoke(appDbContext, null);

            // Get the Find method from DbSet<T>
            MethodInfo findMethod = typeof(DbSet<>).MakeGenericType(type).GetMethod("Find", new[] { typeof(object[]) });

            // Assuming the primary key property is named "Id" and is of a common type like int, Guid, etc.
            PropertyInfo keyProperty = type.GetProperty("Id");
            if (keyProperty == null)
            {
                throw new ArgumentException($"The type {type.Name} does not have a property named 'Id'.");
            }

            object key = keyProperty.GetValue(item);

            // Find the existing entity
            object existingItem = findMethod.Invoke(dbSet, new object[] { new object[] { key } });

            if (existingItem != null)
            {
                // Update the existing entity with new values
                appDbContext.Entry(existingItem).CurrentValues.SetValues(item);
                appDbContext.Entry(existingItem).State = EntityState.Modified;

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception Data.Update: {ex.Message}, \nInner: {ex.InnerException?.Message}");

            return false;
        }
    }

    public static async Task<bool> UpdateAsync(AppDbContext appDbContext, object item)
    {
        try
        {
            Type type = item.GetType();

            // Get the Set<T> method from DbContext
            MethodInfo setMethod = typeof(AppDbContext).GetMethod("Set", Type.EmptyTypes).MakeGenericMethod(type);

            // Invoke the Set<T> method to get the DbSet<T>
            object dbSet = setMethod.Invoke(appDbContext, null);

            // Get the FindAsync method from DbSet<T>
            MethodInfo findAsyncMethod = typeof(DbSet<>).MakeGenericType(type).GetMethod("FindAsync", new[] { typeof(object[]) });

            // Assuming the primary key property is named "Id" and is of a common type like int, Guid, etc.
            PropertyInfo keyProperty = type.GetProperty("Id");
            if (keyProperty == null)
            {
                throw new ArgumentException($"The type {type.Name} does not have a property named 'Id'.");
            }

            object key = keyProperty.GetValue(item);

            // Find the existing entity asynchronously
            var findTask = (dynamic)findAsyncMethod.Invoke(dbSet, new object[] { new object[] { key } });
            object existingItem = await findTask;

            if (existingItem != null)
            {
                // Update the existing entity with new values
                appDbContext.Entry(existingItem).CurrentValues.SetValues(item);
                appDbContext.Entry(existingItem).State = EntityState.Modified;

                // Save the changes asynchronously
                await appDbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            // TODO: Log Exception
            Console.WriteLine($"Exception Data.UpdateAsync: {ex.Message}, \nInner: {ex.InnerException?.Message}");

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
                if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string))
                    columnValues.Add(prop.Name);
            csvBuilder.AppendLine(string.Join(_seperator, columnValues));


            // Add Values
            foreach (var item in data)
            {
                var lineValues = new List<string>();

                foreach (var prop in properties)
                {
                    var propValue = prop.GetValue(item);

                    if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string))
                        lineValues.Add(propValue?.ToString() ?? "");
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
                // TODO: Log Exception
                Console.WriteLine($"Exception Data.ImportFromCsv: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                return null;
            }
        }
    }

    private static void _setProperty<T>(T instance, string propertyName, string propertyValue)
    {
        PropertyInfo property = typeof(T).GetProperty(propertyName);
        if (property != null && property.CanWrite)
        {
            Type propertyType = property.PropertyType;
            object value = Convert.ChangeType(propertyValue, propertyType);
            property.SetValue(instance, value);
        }
    }
}

public enum FileType
{
    CSV
}
