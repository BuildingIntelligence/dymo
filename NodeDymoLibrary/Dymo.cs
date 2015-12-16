using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DYMO.Label.Framework;

namespace NodeDymoLib
{
    public class Dymo
    {

        public async Task<object> Printers(object input)
        {
            IPrinters printers = new Printers();
            return printers;
        }

        public async Task<object> Print(object args)
        {
            IDictionary<string, object> parameters = (IDictionary<string, object>)args;
            ILabel label = Label.Open((string)parameters["label"]);

            if (null != parameters["fields"])
            {
                IDictionary<string, object> fields = (IDictionary<string, object>)parameters["fields"];
                foreach (var kv in fields)
                {
                    try
                    {
                        var k = kv.Key.ToUpper();
                        var obj = label.GetObjectByName(k);
                        if (obj != null)
                        {
                            var v = kv.Value.ToString();
                            label.SetObjectText(k, v);
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                }
            }

            if (null != parameters["images"])
            {
                IDictionary<string, object> images = (IDictionary<string, object>)parameters["images"];
                foreach (var kv in images)
                {
                    try
                    {
                        var k = kv.Key.ToUpper();
                        var obj = label.GetObjectByName(k);
                        if (obj != null)
                        {
                            var v = kv.Value;
                            label.SetImagePngData(k, new MemoryStream((byte[])v));
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            label.Print((string)parameters["printer"]);


            return args;
        }

    }
}
