using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace ConsoleApp1
{
    public class Reflector
    {
        public Type type;
        public Reflector(string type)
        {
            this.type = Type.GetType(type, false, true);
        }
        public Reflector(Type type)
        {
            this.type = type;
        }
        public void AboutClass()
        //вся инфа о классе
        {
            using (FileStream fstream = new FileStream(this.type.Name + " class.txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                foreach (MemberInfo info in type.GetMembers())//GetMembers возвращает члены (свойства, методы, поля, события и т. д.) текущего объекта Type.
                {
                    sw.WriteLine(info.DeclaringType + " - " + info.MemberType + " - " + info.Name + "\n");
                }
                sw.Close();
            }
        }

        public void PublicMethods()
        {
            using (FileStream fstream = new FileStream(this.type.Name + " methods.txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                foreach (MethodInfo method in type.GetMethods())
                {
                    if (method.IsPublic)
                    {
                        sw.WriteLine(method.Name + "\n");//Массив байтов, содержащий результаты кодирования указанного набора символов.
                    }
                }
                sw.Close();
            }
        }
        public void Fields()
        {
            using (FileStream fstream = new FileStream(this.type.Name + " fields_properties.txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                foreach (FieldInfo field in type.GetFields())
                {
                    sw.WriteLine(field.FieldType + " - " + field.Name + "\n");
                }
                foreach (PropertyInfo prorertie in type.GetProperties())
                {
                    sw.WriteLine(prorertie.PropertyType + " - " + prorertie.Name + "\n");
                }
                sw.Close();
            }
        }
        public void Interfaces()
        {
            using (FileStream fstream = new FileStream(this.type.Name + " interfaces.txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                foreach (Type interfaces in type.GetInterfaces())
                {
                    sw.WriteLine(interfaces.DeclaringType + " - " + interfaces.MemberType + " - " + interfaces.Name + "\n");
                }
                sw.Close();
            }
        }
        public void Methods()
        {
            var methods = type.GetMethods();
            Console.Write("Введите тип параметра: ");
            string name = Console.ReadLine();
            Type paramtype = typeof(int);
            var result = methods.Where(a => a.GetParameters().Where(t => t.ParameterType.Name.ToLower() == name.ToLower()).Count() != 0);
            Console.WriteLine($"Все методы, содержащие заданный параметр {name}: ");
            foreach (var el in result)
                Console.WriteLine(el.Name);
        }
        public void Runtimemethod(string method)
        {
            FileStream fstream = new FileStream("param.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fstream);
            object obj = Activator.CreateInstance(type);
            string r;
            r = sr.ReadToEnd();
            MethodInfo m = type.GetMethod(method);
            m.Invoke(obj, new object[] {r});
        }

    }
}
