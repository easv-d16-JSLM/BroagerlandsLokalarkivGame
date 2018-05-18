using Microsoft.EntityFrameworkCore;
using BLAG.Common.Models;

namespace BLAG.Server.Data
{
    public class BlagContext : DbContext
    {
        public BlagContext(DbContextOptions<BlagContext> options) : base(options)
        { }

        public virtual DbSet<AnswerMap> AnswerMaps { get; set; }
        public virtual DbSet<AnswerNumber> AnswerNumbers { get; set; }
        public virtual DbSet<AnswerPicture> AnswerPictures { get; set; }
        public virtual DbSet<AnswerTextChoice> AnswerTextChoices { get; set; }
        public virtual DbSet<QuestionAudio> QuestionAudios { get; set; }
        public virtual DbSet<QuestionText> QuestionTexts { get; set; }
        public virtual DbSet<QuestionImage> QuestionImages { get; set; }
        public virtual DbSet<QuestionVideo> QuestionVideos { get; set; }
        public virtual DbSet<Questionnaire> Questionnaires { get; set; }
    }
}
