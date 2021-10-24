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

using (StreamWriter w = new StreamWriter("./main.cpp",true)){
    
    w.WriteLine("#include <iostream>");
    w.WriteLine("using namespace std;");
    w.WriteLine("int main(){");
    w.WriteLine("\tint x = 0;");
    w.WriteLine("\tcout << \"请给出一个不多于5位的整数:\";");
    w.WriteLine("\tcin >> x;");
    w.WriteLine("\tswitch(x){");

    for(var i = 0;i < 100000;i++){
        w.WriteLine($"\t\tcase {i}:");
        string stri = i.ToString();
        int len = stri.Length;
        w.WriteLine($"\t\t\tcout << \"是{len}位数\" << endl;");
        for(var d = 0;d < len;d++){
            w.WriteLine($"\t\t\tcout << \"{units[d]}位是: {stri[d]}\" << endl;");
        }
        w.WriteLine($"\t\t\tcout << \"倒过来是: {Reverse(i)}\" << endl;");
        w.WriteLine("\t\t\tbreak;");
    }

    w.Write("\t}\n\treturn 0;\n}");
}
