using System;
using System.Collections.Generic;

namespace Ex01
{
    public class ZodiacSignManager
    {
        private Dictionary<string, string> m_Horoscope = new Dictionary<string, string>();
        private string m_ZodiacHoroscope;
        private string m_ZodiacSign;
        private DateTime m_Birthday;

        public ZodiacSignManager(DateTime i_Dt)
        {
            this.initializeHoroscopeDictionary();
            this.m_Birthday = i_Dt;
            this.m_ZodiacSign = GetZodiacSign(this.m_Birthday);
            this.m_ZodiacHoroscope = this.m_Horoscope[this.m_ZodiacSign];
        }

        public string ZodiacHoroscop
        {
            get { return this.m_ZodiacHoroscope; }
        }

        public string ZodiacSign
        {
            get { return this.m_ZodiacSign; }
        }

        internal static string GetZodiacSign(DateTime io_userBirthdaydate)
        {
            int month = io_userBirthdaydate.Month;
            int day = io_userBirthdaydate.Day;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                    {
                        return "Capricorn";
                    }
                    else
                    {
                        return "Aquarius";
                    }

                case 2:
                    if (day <= 18)
                    {
                        return "Aquarius";
                    }
                    else
                    {
                        return "Pisces";
                    }

                case 3:
                    if (day <= 20)
                    {
                        return "Pisces";
                    }
                    else
                    {
                        return "Aries";
                    }

                case 4:
                    if (day <= 19)
                    {
                        return "Aries";
                    }
                    else
                    {
                        return "Taurus";
                    }

                case 5:
                    if (day <= 20)
                    {
                        return "Taurus";
                    }
                    else
                    {
                        return "Gemini";
                    }

                case 6:
                    if (day <= 20)
                    {
                        return "Gemini";
                    }
                    else
                    {
                        return "Cancer";
                    }

                case 7:
                    if (day <= 22)
                    {
                        return "Cancer";
                    }
                    else
                    {
                        return "Leo";
                    }

                case 8:
                    if (day <= 22)
                    {
                        return "Leo";
                    }
                    else
                    {
                        return "Virgo";
                    }

                case 9:
                    if (day <= 22)
                    {
                        return "Virgo";
                    }
                    else
                    {
                        return "Libra";
                    }

                case 10:
                    if (day <= 22)
                    {
                        return "Libra";
                    }
                    else
                    {
                        return "Scorpio";
                    }

                case 11:
                    if (day <= 21)
                    {
                        return "Scorpio";
                    }
                    else
                    {
                        return "Sagittarius";
                    }

                case 12:
                    if (day <= 21)
                    {
                        return "Sagittarius";
                    }
                    else
                    {
                        return "Capricorn";
                    }

                default:
                    return string.Empty;
            }
        }

        private void initializeHoroscopeDictionary()
        {
            this.m_Horoscope["Capricorn"] = "Capricorn sign knows what he wants. Capricorn sign has good manners. Capricorn sign adores success and power. Capricorn sign does not allow emotions to blind him." +
                " Capricorn sign may fall ill because of anxiety. Capricorn woman loves beauty." +
                " Capricorn man is a strong with gentle heart.";
            this.m_Horoscope["Sagittarius"] = "Sagittarius sign is a cheerful idealist." +
                " Sagittarius sign is very fortunate and quickly advances forward." +
                " Sagittarius sign love is superficial, but honest. Sagittarius sign is seldom ill and quickly recovers." +
                " Sagittarius woman is very independent." +
                " Sagittarius man thinks both with mind and heart.";
            this.m_Horoscope["Scorpio"] = "Scorpio sign is an expression of selfishness. Scorpio sign is philosopher by nature." +
                " Scorpio sign can achieve everything. Scorpio sign unites the reason and passions." +
                " Scorpio sign people are seldom ill. Scorpio woman possesses deep mysterious beauty." +
                " Scorpio man is passionate in all.";
            this.m_Horoscope["Libra"] = "Libra sign is pleasant, kind, and active." +
                " Libra sign penetrates into the essence of any matter. Libra sign is extremely responsible." +
                " Love and balance are synonyms for Libra sign. Libra sign is physically and intellectually healthy." +
                " Libra woman thinks with man's logic." +
                " Libra man does not like to say No.";
            this.m_Horoscope["Virgo"] = "Virgo sign is open-hearted, sincere, and likes punctuality, thrift and inventiveness." +
                " Virgo sign is practical. Virgo sign shares love quietly and equally." +
                " Virgo sign cares of the body and right nutrition. For Virgo woman beauty is truth." +
                " Virgo man unites sharp intelligence and earthly predilections.";
            this.m_Horoscope["Leo"] = "Leadership is characteristic for Leo sign. Leo sign is a real friend." +
                " Leo sign is successful in all undertakings. Life without love does not exist for Leo sign." +
                " People of Leo sign are surprisingly viable. Almost all men easily fall in love with Leo woman." +
                " Leo man is a gentle protector and sentimental lover.";
            this.m_Horoscope["Cancer"] = "Cancer sign may suffer from melancholy and fears." +
                " Cancer sign likes to save money. Cancer woman is changeable in love." +
                " Cancer man is gallant and sentimental. Cancer sign may fall ill due to proper emotions." +
                " Modesty is characteristic for Cancer woman." +
                " Quality and pleasure are synonyms for Cancer.";
            this.m_Horoscope["Gemini"] = "Gemini sign is intellectual sign." +
                " People of Gemini sign are graceful and clever." +
                " For Gemini sign money and love are always not enough." +
                " Gemini sign love is illusory. Gemini sign may suffer from nervous breakdowns." +
                " Gemini woman is not interested in terrestrial passions." +
                " Gemini man is in permanent change.";
            this.m_Horoscope["Taurus"] = "Taurus sign people are stubborn and accept things such as they are." +
                " Taurus sign is faithful and capable for strong love. Taurus sign and money are inseparable." +
                " Taurus sign is usually healthy. Taurus woman combines all remarkable qualities." +
                " Taurus man is created for woman who appreciates true values.";
            this.m_Horoscope["Aries"] = "People of Aries sign are open-hearted and strong." +
                " Their main features are frankness and honesty. Aries sign loves work." +
                " Aries sign is true and fair in love. Aries sign is seldom ill." +
                " Aries woman is intellectual and extremely strong." +
                " Aries man is overflown with ideas and creative energy.";
            this.m_Horoscope["Pisces"] = "Life is a huge stage for Pisces sign." +
                " People of Pisces sign may become good writers or artists. Pisces sign ambitions are few." +
                " People of Pisces sign are great romanticists. Pisces sign should abstain from troubles and overwork." +
                " Pisces woman is awfully sentimental. Pisces man is a real godsend for any woman.";
            this.m_Horoscope["Aquarius"] = "The key feature of Aquarius sign is curiosity and the ability of deep insight." +
                " Aquarius sign is the sign of geniuses. Aquarius sign is contradictory in love." +
                " Aquarius sign has a very sensitive nervous system. Aquarius woman belongs to all and nobody." +
                " Aquarius man may be a good friend and clever adviser.";
        }
    }
}
