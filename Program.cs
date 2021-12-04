using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string puzzleInput = System.IO.File.ReadAllText("E:\\Archive\\Repos\\MyCode\\Advent of Code\\2020\\Day 4\\input.txt");

            var passports = puzzleInput.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var validPassports = 0;

            foreach (var passport in passports)
            {
                var validFields = 0;
                var passportFields = passport.Split(new string[] { " " , "\r\n" },StringSplitOptions.None);
                var splitPassportFields = new List<string[]>();
                foreach (var passportField in passportFields)
                {
                    splitPassportFields.Add(passportField.Split(":"));
                }

                for (int i = 0; i < splitPassportFields.Count; i++)
                {
                    if (splitPassportFields[i][0]=="byr")
                    {
                        if (int.Parse(splitPassportFields[i][1]) >= 1920 && int.Parse(splitPassportFields[i][1]) <= 2002)
                        {
                            validFields++;
                        }
                    }

                    if (splitPassportFields[i][0] == "iyr")
                    {
                        if (int.Parse(splitPassportFields[i][1]) >= 2010 && int.Parse(splitPassportFields[i][1]) <= 2020)
                        {
                            validFields++;
                        }
                    }

                    if (splitPassportFields[i][0] == "eyr")
                    {
                        if (int.Parse(splitPassportFields[i][1]) >= 2020 && int.Parse(splitPassportFields[i][1]) <= 2030)
                        {
                            validFields++;
                        }
                    }

                    if (splitPassportFields[i][0] == "hgt")
                    {
                        if (getHeightUnit(splitPassportFields[i][1]) =="cm")
                        {
                            if (getHeightValue(splitPassportFields[i][1]) >= 150 && getHeightValue(splitPassportFields[i][1]) <= 193)
                            {
                                validFields++;
                            }
                        }
                        if (getHeightUnit(splitPassportFields[i][1]) == "in")
                        {
                            if (getHeightValue(splitPassportFields[i][1]) >= 59 && getHeightValue(splitPassportFields[i][1]) <= 76)
                            {
                                validFields++;
                            }
                        }
                    }                                               

                    if (splitPassportFields[i][0] == "hcl")
                    {
                        if (splitPassportFields[i][1][0]=='#' && splitPassportFields[i][1].Length==7)
                        {
                            validFields++;
                        }
                    }

                    if (splitPassportFields[i][0] == "ecl")
                    {
                        if (splitPassportFields[i][1].Contains("amb")||
                            splitPassportFields[i][1].Contains("blu") ||
                            splitPassportFields[i][1].Contains("brn") ||
                            splitPassportFields[i][1].Contains("gry") ||
                            splitPassportFields[i][1].Contains("grn") ||
                            splitPassportFields[i][1].Contains("hzl") ||
                            splitPassportFields[i][1].Contains("oth"))
                        {
                            validFields++;
                        }
                    }

                    if (splitPassportFields[i][0] == "pid")
                    {
                        if (validatePid(splitPassportFields[i][1]))
                        {
                            if (splitPassportFields[i][1].Length==9)
                            {
                            validFields++;
                            }
                        }
                    }
                }
                 

                if (validFields==7)
                {
                    validPassports++;
                }

            }
            Console.WriteLine(validPassports);
        }

        public static string getHeightUnit(String input)
        {
            Regex regex = new Regex("[a-zA-Z]+", RegexOptions.IgnoreCase);
            return regex.Match(input).Value;
        }

        public static bool validatePid(String input)
        {
            Regex regex = new Regex("^[0-9]+$", RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
        }

        public static int getHeightValue(String input)
        {
            Regex regex = new Regex("[0-9]+", RegexOptions.IgnoreCase);
            return int.Parse(regex.Match(input).Value);
        }
    }
}
