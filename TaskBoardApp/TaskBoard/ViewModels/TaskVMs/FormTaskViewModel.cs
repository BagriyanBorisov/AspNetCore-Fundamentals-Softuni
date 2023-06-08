using System.Drawing;
using TaskBoard.ViewModels.BoardVMs;

namespace TaskBoard.ViewModels.TaskVMs
{
    using System.ComponentModel.DataAnnotations;
    using static Common.Validations.EntityValidations.TaskValidations;

    public class FormTaskViewModel
    {
        public FormTaskViewModel()
        {
            this.Boards = new List<FormBoardViewModel>();
        }

        [Required]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength, ErrorMessage = ErrorMsgTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength, ErrorMessage = ErrorMsgDescription)]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<FormBoardViewModel> Boards { get; set; }
    }
}
