
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace odev2
{
    public class BinaryTree
    {

        public string veri; 
        public int indis;
        public BinaryTree sag, sol;
        public string isim;
        public List<string> s1, s3, s4, s6;
        public List<int> s2, s5;
        public List<string> h1, h3, h4, h6;
        public List<int> h2, h5;
        public BinaryTree()
        {
            s1 = new List<string>();
            s3 = new List<string>();
            s4 = new List<string>();
            s6 = new List<string>();
            s2 = new List<int>();
            s5 = new List<int>();


            h1 = new List<string>();
            h3 = new List<string>();
            h4 = new List<string>();
            h6 = new List<string>();
            h2 = new List<int>();
            h5 = new List<int>();

            sag = null;
            sol = null;




        }

        public override string ToString()
        {
            return 
                     "isim :" + isim + "   ";
        }
    }
}