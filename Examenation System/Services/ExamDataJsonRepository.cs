using Examenation_System.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.Services
{
    class ExamDataJsonRepository : IExamDataRepository
    {

        public void AddExamBox(ExamData exam)
        {
            var examList = Read();
            examList.Add(exam);
            Write(examList);
        }

        public void RemoveExamBox(int index)
        {
            var examList = Read();
            examList.RemoveAt(index);
            Write(examList);
        }



        public void AddTest(Exam exam, int examIndex)
        {
            var examList = Read();
            examList[examIndex].Quetion.Add(exam);
            Write(examList);
        }

        public void RemoveTest(int examIndex, int testIndex)
        {
            var examList = Read();
            examList[examIndex].Quetion.RemoveAt(testIndex);
            Write(examList);
        }

        public void AddTestByIndex( Exam exam, int examIndex, int testIndex)
        {
            var examList = Read();
            examList[examIndex].Quetion.Insert(testIndex,exam);
            Write(examList);
        }



        public List<ExamData> GetAllTasks()
        {
            return Read();
        }

        private List<ExamData> Read()
        {
            if (File.Exists("ExamData.json"))
            {
                return JsonConvert.DeserializeObject<List<ExamData>>(File.ReadAllText("ExamData.json"));
            }
            return new List<ExamData>();
        }

        private void Write(List<ExamData> examList)
        {
            File.WriteAllText("ExamData.json", JsonConvert.SerializeObject(examList));
        }
    }
}
