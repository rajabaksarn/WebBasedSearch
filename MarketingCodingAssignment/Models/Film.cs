﻿using System.ComponentModel;

namespace MarketingCodingAssignment.Models
{
    public class Film
    {
        private string id;

        public string Id
        {
            get => id; set => id = value;
        }

        public string? Title
        {
            get; set;
        }

        public string? Overview
        {
            get; set;
        }

    }
}
