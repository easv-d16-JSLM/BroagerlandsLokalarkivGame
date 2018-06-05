using System;
using System.Collections.Generic;
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
            foreach (var collectionName in _db.Database.GetCollectionNames())
            {
                _db.Database.DropCollection(collectionName);
            }

            var questionnaire1 = _db.Insert(new Questionnaire
            {
                Title = "Broager i 1864",
                Questions = new List<Question>()
            });
            var questionnaire2 = _db.Insert(new Questionnaire
            {
                Title = "Broager i Bronzealderen",
                Questions = new List<Question>()
            });

            var question1 = _db.Insert(new Question
            {
                Content = "Hvem af disse personer deltog i krigen ved dybbøl?",
                Points = 700,
                QuestionType = QuestionType.Text,
                Time = TimeSpan.FromSeconds(30)
            });

            var question2 = _db.Insert(new Question
            {
                Content = "Hvem af disse personer døde i krigen ved dybbøl?",
                Points = 500,
                QuestionType = QuestionType.Text,
                Time = TimeSpan.FromSeconds(30)
            });
            var update1 = _db.SingleById<Questionnaire>(questionnaire1);
            update1.Questions.Add(_db.SingleById<Question>(question1));
            update1.Questions.Add(_db.SingleById<Question>(question2));
            _db.Update(update1);

            var question3 = _db.Insert(new Question
            {
                Content = "Hvor stor var Broager i Bronzealderen?",
                Points = 600,
                QuestionType = QuestionType.Text,
                Time = TimeSpan.FromSeconds(30)
            });
            var question4 = _db.Insert(new Question
            {
                Content = "Hvor mange boede i broager i Bronzealderen?",
                Points = 400,
                QuestionType = QuestionType.Text,
                Time = TimeSpan.FromSeconds(30)
            });

            var update2 = _db.SingleById<Questionnaire>(questionnaire2);
            update2.Questions.Add(_db.SingleById<Question>(question3));
            update2.Questions.Add(_db.SingleById<Question>(question4));
            _db.Update(update2);

            _db.Insert(new Answer
            {
                Options = new List<string>
                {
                    "Henrik",
                    "Peter",
                    "Lise",
                    "Lars"
                },
                CorrectAnswer = "Henrik",
                AnswerType = QuestionType.Text,
                Question = _db.SingleById<Question>(question1)
            });
            _db.Insert(new Answer
            {
                Options = new List<string>
                {
                    "Hansen",
                    "Peter",
                    "Henrik",
                    "Ludvig"
                },
                CorrectAnswer = "Henrik",
                AnswerType = QuestionType.Text,
                Question = _db.SingleById<Question>(question2)
            });
            _db.Insert(new Answer
            {
                Options = new List<string>
                {
                    "10 km2",
                    "15 km2",
                    "20 km2",
                    "30 km2"
                },
                CorrectAnswer = "15 km2",
                AnswerType = QuestionType.Text,
                Question = _db.SingleById<Question>(question3)
            });
            _db.Insert(new Answer
            {
                Options = new List<string>
                {
                    "100",
                    "200",
                    "500",
                    "350"
                },
                CorrectAnswer = "350",
                AnswerType = QuestionType.Text,
                Question = _db.SingleById<Question>(question4)
            });

            _db.Insert(new GameSession
            {
                Questionnaire = _db.SingleById<Questionnaire>(questionnaire1),
                StartTime = DateTime.Now,
                JoinCode = "abcde"
            });
            _db.Insert(new GameSession
            {
                Questionnaire = _db.SingleById<Questionnaire>(questionnaire2),
                StartTime = DateTime.Now,
                JoinCode = "12345"
            });
        }
    }
}