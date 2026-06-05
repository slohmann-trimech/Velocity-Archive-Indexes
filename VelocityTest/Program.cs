using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityDb;
using TriMech.Dms;
using TriMech.Dms.DmsDataDoctor.DataDocObjects;
using VelocityDb.Session;

namespace VelocityTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (SessionNoServer session = new SessionNoServer(@"S:\Staging Area\J&J\2026-05-28_AM091058_DataDoctor\Velocity"))
            {

                session.BeginRead();

                var dataDocObjects = session.AllObjects<DataDocDocumentInfo>()
                    .Where(x => x.DocumentIndex != null);

                int count = dataDocObjects.Count();
                Console.WriteLine($"Found {count} DataDocDocumentInfo objects with non-null DocumentIndex.");

                foreach (var dataDocObject in dataDocObjects)
                {
                    Console.WriteLine(dataDocObject.DocumentIndex.Filename);
                }

                session.Commit();

            }

            

        }
    }
}
