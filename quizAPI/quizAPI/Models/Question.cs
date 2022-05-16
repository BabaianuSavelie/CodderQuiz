﻿using System.ComponentModel.DataAnnotations;

namespace quizAPI.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int CorectAnswer { get; set; }
    }
}
