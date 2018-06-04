using System;
using BLAG.Common.Models;
using LiteDB;

namespace BLAG.Server
{
    public class DbInitializer
    {
        private readonly LiteRepository _db;

        public DbInitializer(LiteRepository db)
        {
            _db = db;
        }

        public void SeedDatabase()
        {
            var questionnaire1 = _db.Insert(new Questionnaire
            {
                Title = "Broager i 1864"
            });
            var questionnaire2 = _db.Insert(new Questionnaire
            {
                Title = "Broager i Bronzealderen"
            });

            _db.Insert(new Question
            {
                Content = "Hvem af disse personer deltog i krigen ved dybbøl?",
                Points = 500,
                Questionnaire = _db.SingleById<Questionnaire>(questionnaire1),
                QuestionType = QuestionType.Text,
                Time = TimeSpan.FromSeconds(30)
            });
            _db.Insert(new Question
            {
                Content = "Hvem af disse personer døde i krigen ved dybbøl?",
                Points = 500,
                Questionnaire = _db.SingleById<Questionnaire>(questionnaire1),
                QuestionType = QuestionType.Text,
                Time = TimeSpan.FromSeconds(30)
            });
            _db.Insert(new Question());
            _db.Insert(new Question());

            _db.Insert(new Answer());
            _db.Insert(new Answer());
            _db.Insert(new Answer());
            _db.Insert(new Answer());
        }
    }
}