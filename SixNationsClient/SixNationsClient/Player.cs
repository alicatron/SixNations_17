using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SixNations2017.Models
{
    
    public enum Position
    {
        Prop, Hooker, Lock,
        Wing, Centre,
        [Display(Name = "Back Row")]
        BackRow,
        [Display(Name = "Number 8")]
        NumberEight,
        [Display(Name = "Scrum Half")]
        ScrumHalf,
        [Display(Name = "Fly Half")]
        FlyHalf,
        [Display(Name = "Full Back")]
        FullBack
    }


    public enum InternationalTeam
    {
        Ireland, England, Scotland, Wales, France, Italy
    }

    public class Player
    {
        public int ID { get; set; }  //primary key and identity

        [Required(ErrorMessage = "Please Enter a Name")]
        public string Name { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public Position Position { get; set;}

        [JsonConverter(typeof(StringEnumConverter))]
        public InternationalTeam InternationalTeam { get; set; }

        [Display(Name = "Tries Scored")]
        [Range(0, 100, ErrorMessage = "Please select a number from 0 - 100")]   //prevent users from selecting a negative number
        public int TriesScored { get; set; }

        [Display(Name = "Conversions Scored")]
        [Range(0, 100, ErrorMessage = "Please select a number from 0 - 100")]
        public int ConversionScored { get; set; }

        
        [Range(0, 100, ErrorMessage = "Please select a number from 0 - 100")]
        public int Penalties { get; set; }

        public int PointsScored
        {
            

            get
            {
                const int Conversion = 2; 
                const int Try = 5;
                const int Penalty = 3;

                int pointsScored = (ConversionScored * Conversion) + (TriesScored * Try) + (Penalties * Penalty);
                return pointsScored;
            }
        }
    }
}