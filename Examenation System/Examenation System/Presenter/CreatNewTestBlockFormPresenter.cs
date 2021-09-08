using Examenation_System.Model;
using Examenation_System.Services;
using Examenation_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.Presenter
{
    class CreatNewTestBlockFormPresenter
    {
       private ICreateNewTestBlockForm testBlock;
       private IExamDataRepository examData;
        public CreatNewTestBlockFormPresenter(ICreateNewTestBlockForm testBlock, IExamDataRepository examData)
        {
        this.testBlock = testBlock;
         this.examData = examData;
         this.testBlock.Add += Add;
        }

        public void Add ()
        {
            var exam = new ExamData();     
            exam.Name = testBlock.BLockName;
            exam.Quetion = new List<Exam>();
            examData.AddExamBox(exam);

        }
    }
}
