using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions
{
    public static class SubjectExtensions
    {
        public static IEnumerable<SubjectInfo> ToSubjectInfo(this IEnumerable<Subject> subjects)
        {
            return subjects.Select(s => s.ToSubjectInfo());
        }

        private static SubjectInfo ToSubjectInfo(this Subject subject)
        {
            return new SubjectInfo
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }
    }
}
