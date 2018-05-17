using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BLAG.Common.Models;

namespace BLAG.Server.Data
{
    public class BlagContext : DbContext
    {
        public BlagContext(DbContextOptions<BlagContext> options)
            : base(options)
        { }

        public DbSet<AnswerMap> AnswerMaps { get; set; }
        public DbSet<AnswerNumber> AnswerNumbers { get; set; }
        public DbSet<AnswerPicture> AnswerPictures { get; set; }
        public DbSet<AnswerTextChoice> AnswerTextChoices { get; set; }
        //public DbSet<QuestionAudio> QuestionAudios { get; set; }
        public DbSet<QuestionText> QuestionTexts { get; set; }
        //public DbSet<QuestionImage> QuestionImages { get; set; }
        //public DbSet<QuestionVideo> QuestionVideos { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
    }
}
