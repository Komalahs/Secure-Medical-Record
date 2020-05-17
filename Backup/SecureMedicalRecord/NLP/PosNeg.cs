using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

namespace SecureMedicalRecord.NLP
{
    public class PosNeg
    {
        Hashtable hp = new Hashtable();
        Hashtable hn = new Hashtable();
        public Hashtable Negativemethod()
        {
            string path = "~/Keypoints/n.txt";
           
            if (File.Exists(HttpContext.Current.Server.MapPath(path)))
            {

                FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(path), FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string line = null;
                while((line=sr.ReadLine())!=null)
                {
                    string[] val=line.Split(',');
                    hn.Add(val[0], val[1]);
                }
                sr.Close();
                fs.Close();
            }
                return hn;

        }

        public Hashtable Positiveemethod()
        {
            string path ="~/Keypoints/P.txt";

            if (File.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(path), FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] val = line.Split(',');
                    hp.Add(val[0], val[1]);
                }
                
                sr.Close();
                fs.Close();
            }
            return hp;
           

        }

    }
}