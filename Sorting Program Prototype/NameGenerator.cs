namespace Sorting_Program_Prototype;
using System;
using System.Linq;
using System.Collections.Generic;

public class NameGenerator
{
    System.Random random = new System.Random();
    
    // Arrays of syllables for each part of the name (prefix, first, middle, last)
    private readonly string[] _prefixes = {"Dr.", "Mrs.", "Mr.", "Miss"};
    private readonly string[] _firstSyllables = {"Aer", "An", "Ar", "At", "Bel", "Cal", "Cel", "Cer", "Dal", "Dar", "Ei", "El", "Fal", "Fel", "Gel", "Gul", "Hal", "Hil", "Ib", "Id", "Il", "In", "Jal", "Jil", "Kel", "Lel", "Mal", "Mel", "Nal", "Nel", "Ol", "Pal", "Pel", "Qi", "Qo", "Ral", "Rel", "Sel", "Sil", "Tal", "Tel", "Ul", "Val", "Vil", "Wel", "Xal", "Xel", "Yal", "Yel", "Zal", "Zel"};
    private readonly string[] _middleSyllables = {"ba", "be", "bi", "bo", "bu", "ca", "ce", "ci", "co", "cu", "da", "de", "di", "do", "du", "fa", "fe", "fi", "fo", "fu", "ga", "ge", "gi", "go", "gu", "ha", "he", "hi", "ho", "hu", "ja", "je", "ji", "jo", "ju", "ka", "ke", "ki", "ko", "ku", "la", "le", "li", "lo", "lu", "ma", "me", "mi", "mo", "mu", "na", "ne", "ni", "no", "nu", "pa", "pe", "pi", "po", "pu", "qa", "qe", "qi", "qo", "qu", "ra", "re", "ri", "ro", "ru", "sa", "se", "si", "so", "su", "ta", "te", "ti", "to", "tu", "va", "ve", "vi", "vo", "vu", "wa", "we", "wi", "wo", "wu", "xa", "xe", "xi", "xo", "xu", "ya", "ye", "yi", "yo", "yu", "za", "ze", "zi", "zo", "zu"};
    private readonly string[] _lastSyllables = {"bain", "baine", "bein", "beine", "bine", "boin", "boine", "buan", "buane", "cain", "caine", "cane", "cein", "ceine", "cine", "cone", "cuan", "cuane", "dain", "daine", "dein", "deine", "dine", "doin", "doine", "duan", "duane", "fain", "faine", "fein", "feine", "fine", "foin", "foine", "fuan", "fuane", "gain", "gaine", "gein", "geine", "gine", "goin", "goine", "guan", "guane", "hain", "haine", "hine", "hoin", "hoine", "huan", "huane", "jain", "jaine", "jine", "join", "joine", "juan", "juane", "kain", "kaine", "kane", "kein", "keine", "kine", "koin", "koine", "kuan", "kuane", "lain", "laine", "lane", "lein", "leine", "line", "loin", "loine", "luan", "luane", "main", "maine", "mane", "mein", "meine", "mine", "moin", "moine", "muan", "muane", "nain", "naine", "nane", "nein", "neine", "nine", "noin", "noine", "nuan", "nuane", "pain", "paine", "pane", "pein", "peine", "pine", "poin", "poine", "puan", "puane", "qain", "qaine", "qine", "qoin", "qoine", "quan", "quane", "rain", "raine", "rane", "rein", "reine", "rine", "roin", "roine", "ruan", "ruane", "sain", "saine", "sane", "sein", "seine", "sine", "soin", "soine", "suan", "suane", "tain", "taine", "tane", "tein", "teine", "tine", "toin", "toine", "tuan", "tuane", "vain", "vaine", "vane", "vein", "veine", "vine", "voin", "voine", "vuan", "vuane", "wain", "waine", "wane", "wein", "weine", "wine", "woin", "woine", "wuan", "wuane", "xain", "xaine", "xane", "xin", "xine", "xoin", "xoine", "xuan", "xuane", "yain", "yaine", "yane", "yein", "yeine", "yine", "yoin", "yoine", "yuan", "yuane", "zain", "zaine", "zane", "zein", "zine", "zoin", "zoine", "zuan", "zuane"};
    
    static void Main(string[] args)
    {
        NameGenerator nameGenerator = new NameGenerator();
        Console.WriteLine(nameGenerator.GenerateRandomName());
    }
    
    public string GenerateRandomName()
    {
        // Select a random prefix, first name, middle name (if applicable), and last name
        string prefix = _prefixes[random.Next(0, _prefixes.Length)];
        string firstName = GetRandomSyllableName(_firstSyllables, random.Next(2, 4));
        string middleName = GetRandomSyllableName(_middleSyllables, random.Next(2, 4));
        string lastName = GetRandomSyllableName(_lastSyllables, random.Next(2, 4));

        // Return the full name
        return $"{prefix} {firstName} {middleName} {lastName}";
    }
    
    private string GetRandomSyllableName(string[] syllables, int syllableCount)
    {
        // Select the specified number of random syllables
        var selectedSyllables = new List<string>();
        for (int i = 0; i < syllableCount; i++)
        {
            selectedSyllables.Add(syllables[random.Next(0, syllables.Length)]);
        }

        // Capitalize the first syllable and return the combined name
        selectedSyllables[0] = char.ToUpper(selectedSyllables[0][0]) + selectedSyllables[0].Substring(1);
        return string.Join("", selectedSyllables);
    }
}