
using Evaluation.UI.DTO.BL061005;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL061005
{
    public class AF1BL061005Root : GenericWebResponse
    {
        public List<AF1BL061005Dto> ArrayOfAF1BL061005 { get; set; }
    }
}
