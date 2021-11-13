using System;
using System.IO;
using System.Text;

string Reverse(int i){
    StringBuilder sb = new StringBuilder();
    do{
        sb.Append(i % 10);
        i /= 10;
    }while(i != 0);
    return sb.ToString();
}

string[] units = new string[]{"个","十","百","千","万"};

using (StreamWriter w = new StreamWriter("./code/Program.cs",true)){
    w.WriteLine("using System;");
    w.WriteLine("int x = 0;");
    w.WriteLine("Console.Write(\"请给出一个不多于5位的整数:\");");
    w.WriteLine("x = Convert.ToInt32(Console.ReadLine());");
    w.WriteLine("switch(x){");

    for(var i = 0;i < 100000;i++){
        w.WriteLine($"\tcase {i}:");
        string stri = i.ToString();
        int len = stri.Length;
        w.WriteLine($"\t\tConsole.WriteLine(\"是{len}位数\");");
        for(var d = 0;d < len;d++){
            w.WriteLine($"\tConsole.WriteLine(\"{units[d]}位是: {stri[d]}\");");
        }
        w.WriteLine($"\t\tConsole.WriteLine(\"倒过来是: {Reverse(i)}\");");
        w.WriteLine("\t\tbreak;");
    }
    w.Write("}");
}
