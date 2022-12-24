Console.WriteLine("Alright ref!");

/*
 * Note
 *
 * Don't confuse the concept of passing by reference with the concept of reference types.
 * The two concepts are not the same.A method parameter can be modified by ref regardless
 * of whether it is a value type or a reference type. There is no boxing of a value type
 * when it is passed by reference.
 */

Console.WriteLine();
Console.WriteLine("Passing an argument by reference.");

Console.WriteLine();
var globalInt = 100;
Console.WriteLine($"#01: {nameof(globalInt)} = {globalInt}"); // 100

Console.WriteLine();
ArgIntMethod(globalInt);
Console.WriteLine($"#02: {nameof(globalInt)} = {globalInt}"); // 100

Console.WriteLine();
ArgRefIntMethod(ref globalInt);
Console.WriteLine($"#03: {nameof(globalInt)} = {globalInt}"); // 200

Console.WriteLine();
var globalStruct = new FirstStruct
{
    IntProp = 1000,
    StrProp = "_str_in_struct_",
    ClassProp = new Class
    {
        DoubleProp = 1000.1d,
        StrProp = "_str_in_class_",
        StructInClassProp = new SecondStruct
        {
            FloatProp = 1000.2f
        }
    },
    StructInStructProp = new SecondStruct
    {
        FloatProp = 1000.3f
    }
};
Console.WriteLine($"#04: {nameof(globalStruct)} = {globalStruct}");

Console.WriteLine();
ArgStructMethod(globalStruct);
Console.WriteLine($"#05: {nameof(globalStruct)} = {globalStruct}");

Console.WriteLine();
ArgRefStructMethod(ref globalStruct);
Console.WriteLine($"#06: {nameof(globalStruct)} = {globalStruct}");

Console.WriteLine();
var globalClass = new Class
{
    DoubleProp = 10.1d,
    StrProp = "_str_",
    StructInClassProp = new SecondStruct
    {
        FloatProp = 10.2f
    }
};
Console.WriteLine($"#07: {nameof(globalClass)} = {globalClass}");

Console.WriteLine();
EditPropsOfArgClassMethod(globalClass);
Console.WriteLine($"#08: {nameof(globalClass)} = {globalClass}");

Console.WriteLine();
EditPropsOfArgRefClassMethod(ref globalClass);
Console.WriteLine($"#09: {nameof(globalClass)} = {globalClass}");

Console.WriteLine();
CreateNewUsingArgClassMethod(globalClass);
Console.WriteLine($"#10: {nameof(globalClass)} = {globalClass}");

Console.WriteLine();
CreateNewUsingArgRefClassMethod(ref globalClass);
Console.WriteLine($"#11: {nameof(globalClass)} = {globalClass}");

void ArgIntMethod(int argInt)
{
    Console.WriteLine($"{nameof(ArgIntMethod)} #1: {nameof(argInt)} = {argInt}"); // 100
    argInt += 100;
    Console.WriteLine($"{nameof(ArgIntMethod)} #2: {nameof(argInt)} = {argInt}"); // 200
}

void ArgRefIntMethod(ref int refArgInt)
{
    Console.WriteLine($"{nameof(ArgRefIntMethod)} #1: {nameof(refArgInt)} = {refArgInt}"); // 100
    refArgInt += 100;
    Console.WriteLine($"{nameof(ArgRefIntMethod)} #2: {nameof(refArgInt)} = {refArgInt}"); // 200
}

void ArgStructMethod(FirstStruct argStruct)
{
    Console.WriteLine($"{nameof(ArgStructMethod)}: #1: {nameof(argStruct)} = {argStruct}");
    argStruct.IntProp += 1000;
    argStruct.StrProp += "modified_";
    argStruct.ClassProp.DoubleProp += 1000;
    argStruct.ClassProp.StrProp += "modified_";
    argStruct.ClassProp.StructInClassProp = new SecondStruct
    {
        FloatProp = argStruct.ClassProp.StructInClassProp.FloatProp + 1000
    };
    argStruct.StructInStructProp = new SecondStruct
    {
        FloatProp = argStruct.StructInStructProp.FloatProp + 1000
    };
    Console.WriteLine($"{nameof(ArgStructMethod)}: #2: {nameof(argStruct)} = {argStruct}");
}

void ArgRefStructMethod(ref FirstStruct refStruct)
{
    Console.WriteLine($"{nameof(ArgRefStructMethod)}: #1: {nameof(refStruct)} = {refStruct}");
    refStruct.IntProp += 1000;
    refStruct.StrProp += "modified_";
    refStruct.ClassProp.DoubleProp += 1000;
    refStruct.ClassProp.StrProp += "modified_";
    refStruct.ClassProp.StructInClassProp = new SecondStruct
    {
        FloatProp = refStruct.ClassProp.StructInClassProp.FloatProp + 1000
    };
    refStruct.StructInStructProp = new SecondStruct
    {
        FloatProp = refStruct.StructInStructProp.FloatProp + 1000
    };
    Console.WriteLine($"{nameof(ArgRefStructMethod)}: #2: {nameof(refStruct)} = {refStruct}");
}

/*
 * Here we use a reference, or a pointer, to access the object's members.
 * By using the pointer in that way, we directly modify the memory where the object is stored,
 * so the changes here will be permanent.
 */
void EditPropsOfArgClassMethod(Class argClass)
{
    Console.WriteLine($"{nameof(EditPropsOfArgClassMethod)}: #1: {nameof(argClass)} = {argClass}");
    argClass.DoubleProp += 10d;
    argClass.StrProp = "modified_";
    argClass.StructInClassProp = new SecondStruct
    {
        FloatProp = argClass.StructInClassProp.FloatProp + 10f
    };
    Console.WriteLine($"{nameof(EditPropsOfArgClassMethod)}: #2: {nameof(argClass)} = {argClass}");
}

/*
 * Just like in the previous method, here we use an address, or a reference, or a pointer,
 * to modify the object's members directly in the memory where the object is stored.
 * In this case, it doesn't matter whether we use the "ref" keyword or not,
 * the effect will always be the same. To observe differences, take a look at the next cases below.
 */
void EditPropsOfArgRefClassMethod(ref Class refClass)
{
    Console.WriteLine($"{nameof(EditPropsOfArgRefClassMethod)}: #1: {nameof(refClass)} = {refClass}");
    refClass.DoubleProp += 10d;
    refClass.StrProp = "modified_";
    refClass.StructInClassProp = new SecondStruct
    {
        FloatProp = refClass.StructInClassProp.FloatProp + 10f
    };
    Console.WriteLine($"{nameof(EditPropsOfArgRefClassMethod)}: #2: {nameof(refClass)} = {refClass}");
}

/*
 * In this case, the modifications are not permanent
 * because the 'argClass' is a value type, a hexadecimal pointer, and
 * it is passed to the method as a value type (without the ref modifier).
 * This means that when the method is called, a copy of 'argClass' is created
 * and this copy is passed as an argument to the method. Inside the method,
 * any changes made to the pointer will not be visible outside of it.
 * By calling the new constructor of the 'Class' object, we create a new object
 * and generate a new hexadecimal value type pointer to the memory of the object,
 * setting the value of that pointer to the local copy of the method argument.
 */
void CreateNewUsingArgClassMethod(Class argClass)
{
    Console.WriteLine($"{nameof(CreateNewUsingArgClassMethod)}: #1: {nameof(argClass)} = {argClass}");
    argClass = new Class
    {
        DoubleProp = 123456789,
        StrProp = "_the_new_one_without_ref_",
        StructInClassProp = new SecondStruct
        {
            FloatProp = 123456789
        }
    };
    Console.WriteLine($"{nameof(CreateNewUsingArgClassMethod)}: #2: {nameof(argClass)} = {argClass}");
}

/*
 * Here we pass a hexadecimal pointer which is a 'value type',
 * but using the "ref" keyword we pass a reference to the memory location
 * where this value of 'value typed' is stored, allowing us to write a new address
 * to a newly created object in the same memory cell. It is important to note that
 * we are not passing the address of the object here, we are passing the address
 * of the location where the address of the object is stored.
 */
void CreateNewUsingArgRefClassMethod(ref Class refClass)
{
    Console.WriteLine($"{nameof(CreateNewUsingArgRefClassMethod)}: #1: {nameof(refClass)} = {refClass}");
    refClass = new Class
    {
        DoubleProp = 987654321,
        StrProp = "_the_new_one_by_ref_",
        StructInClassProp = new SecondStruct
        {
            FloatProp = 987654321
        }
    };
    Console.WriteLine($"{nameof(CreateNewUsingArgRefClassMethod)}: #2: {nameof(refClass)} = {refClass}");
}