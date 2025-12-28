using System.Collections.Generic;

namespace GetStartedApp.Services;

public static class LanguageService
{
    public static string CurrentLanguage { get; set; } = "pl";
    public static double GlobalFontSize { get; set; } = 20.0;
    public static string GlobalButtonSize { get; set; } = "md";
    public static string OneHandKeyboardAlignment { get; set; } = "right";
    public static string CurrentTheme { get; set; } = "dark";

    private static Dictionary<string, Dictionary<string, string>> translations = new()
    {
        ["pl"] = new()
        {
            // Main Menu
            ["MainMenuTitle"] = "Główne Menu",
            ["KeyboardButton"] = "KLAWIATURA",
            ["SettingsButton"] = "USTAWIENIA",
            ["LanguageButton"] = "JĘZYK",
            ["AndroidTvButton"] = "ANDROID TV",
            ["OneHandKeyboardButton"] = "KLAWIATURA JEDNĄ RĘKĄ",
            
            // Settings
            ["SettingsTitle"] = "Ustawienia",
            ["InfoButton"] = "INFO",
            ["WiFiButton"] = "WI-FI",
            ["FontSizeButton"] = "ROZMIAR CZCIONKI",
            ["ButtonSizeButton"] = "ROZMIAR KLAWIATURY",
            ["WordListButton"] = "LISTA SŁÓW",
            ["ThemesButton"] = "MOTYWY",
            
            // Font Size
            ["FontSizeTitle"] = "Rozmiar Czcionki",
            ["FontSizeLabel"] = "Rozmiar:",
            ["PreviewText"] = "Podgląd tekstu",
            ["SaveButton"] = "ZAPISZ",
            
            // Keyboard Size
            ["ButtonSizeTitle"] = "Rozmiar Klawiatury",
            ["XsSize"] = "XS - Bardzo mały",
            ["SSize"] = "S - Mały",
            ["MdSize"] = "MD - Średni",
            ["LSize"] = "L - Duży",
            ["XlSize"] = "XL - Bardzo duży",
            
            // Word List
            ["WordListTitle"] = "Lista Słów",
            ["WordListInstructions"] = "Wprowadź swoje słowa (jedno słowo na linię):",
            ["WordListPlaceholder"] = "Wprowadź słowa tutaj...",
            ["WordCount"] = "Liczba słów:",
            ["ClearButton"] = "WYCZYŚĆ",
            ["EnterButton"] = "Enter (Nowa linia)",
            
            // Themes
            ["ThemesTitle"] = "Wybierz Motyw",
            ["DarkMode"] = "Tryb Ciemny",
            ["DarkModeDesc"] = "Ciemne tło, jasny tekst",
            ["LightMode"] = "Tryb Jasny",
            ["LightModeDesc"] = "Jasne tło, ciemny tekst",
            
            // Info
            ["InfoTitle"] = "O PowerHID",
            ["InfoDescription"] = "PowerHID to inteligentna klawiatura stworzona dla lepszej dostępności. Dostosuj rozmiary przycisków, układy i metody wprowadzania tekstu dla idealnego doświadczenia. Obsługa wielu profili i spersonalizowanych ustawień.",
            ["FeaturesTitle"] = "Features",
            ["Feature1"] = "Konfigurowalne układy klawiszy",
            ["Feature2"] = "Motywy z wysokim kontrastem",
            ["Feature3"] = "Obsługa jedną ręką",
            ["Feature4"] = "Adaptacyjne metody wprowadzania",
            ["CloseButton"] = "ZAMKNIJ",
            
            // Language
            ["LanguageTitle"] = "Wybierz Język",
            ["PolishLanguage"] = "Polski",
            ["EnglishLanguage"] = "Angielski",
            
            // One Hand Keyboard
            ["OneHandKeyboardTitle"] = "Klawiatura Jedną Ręką",
            ["OneHandKeyboardDesc"] = "Wybierz wyrównanie klawiatury",
            ["LeftAlignment"] = "Lewe wyrównanie",
            ["LeftAlignmentDesc"] = "Klawiatura po lewej stronie",
            ["RightAlignment"] = "Prawe wyrównanie",
            ["RightAlignmentDesc"] = "Klawiatura po prawej stronie"
        },
        ["en"] = new()
        {
            // Main Menu
            ["MainMenuTitle"] = "Main Menu",
            ["KeyboardButton"] = "KEYBOARD",
            ["SettingsButton"] = "SETTINGS",
            ["LanguageButton"] = "LANGUAGE",
            ["AndroidTvButton"] = "ANDROID TV",
            
            // Settings
            ["SettingsTitle"] = "Settings",
            ["InfoButton"] = "INFO",
            ["WiFiButton"] = "WI-FI",
            ["FontSizeButton"] = "FONT SIZE",
            ["ButtonSizeButton"] = "KEYBOARD SIZE",
            ["WordListButton"] = "WORD LIST",
            ["ThemesButton"] = "THEMES",
            
            // Font Size
            ["FontSizeTitle"] = "Font Size",
            ["FontSizeLabel"] = "Size:",
            ["PreviewText"] = "Preview text",
            ["SaveButton"] = "SAVE",
            
            // Keyboard Size
            ["ButtonSizeTitle"] = "Keyboard Size",
            ["XsSize"] = "XS - Extra Small",
            ["SSize"] = "S - Small",
            ["MdSize"] = "MD - Medium",
            ["LSize"] = "L - Large",
            ["XlSize"] = "XL - Extra Large",
            
            // Word List
            ["WordListTitle"] = "Word List",
            ["WordListInstructions"] = "Enter your words (one word per line):",
            ["WordListPlaceholder"] = "Enter words here...",
            ["WordCount"] = "Word count:",
            ["ClearButton"] = "CLEAR",
            ["EnterButton"] = "Enter (New line)",
            
            // Themes
            ["ThemesTitle"] = "Choose Theme",
            ["DarkMode"] = "Dark Mode",
            ["DarkModeDesc"] = "Dark background, light text",
            ["LightMode"] = "Light Mode",
            ["LightModeDesc"] = "Light background, dark text",
            
            // Info
            ["InfoTitle"] = "About PowerHID",
            ["InfoDescription"] = "The application provides intelligent keyboard designed for better accessibility. Customize button sizes, layouts, and text input methods for the perfect experience. Support for multiple profiles and personalized settings.",
            ["FeaturesTitle"] = "Features",
            ["Feature1"] = "Configurable keyboard layouts",
            ["Feature2"] = "High contrast themes",
            ["Feature3"] = "One-handed operation",
            ["Feature4"] = "Adaptive input methods",
            ["CloseButton"] = "CLOSE",
            
            // Language
            ["LanguageTitle"] = "Choose Language",
            ["PolishLanguage"] = "Polish",
            ["EnglishLanguage"] = "English",
            
            // One Hand Keyboard
            ["OneHandKeyboardButton"] = "ONE HAND KEYBOARD",
            ["OneHandKeyboardTitle"] = "One Hand Keyboard",
            ["OneHandKeyboardDesc"] = "Choose keyboard alignment",
            ["LeftAlignment"] = "Left Alignment",
            ["LeftAlignmentDesc"] = "Keyboard on the left side",
            ["RightAlignment"] = "Right Alignment",
            ["RightAlignmentDesc"] = "Keyboard on the right side"
        }
    };

    public static string Get(string key)
    {
        if (translations.ContainsKey(CurrentLanguage) && 
            translations[CurrentLanguage].ContainsKey(key))
        {
            return translations[CurrentLanguage][key];
        }
        return key;
    }

    public static string GetBackgroundColor()
    {
        return CurrentTheme == "light" ? "#FFFFFF" : "#2C3E50";
    }

    public static string GetForegroundColor()
    {
        return CurrentTheme == "light" ? "#000000" : "#FFFFFF";
    }

    public static string GetKeyboardBackgroundColor()
    {
        return CurrentTheme == "light" ? "#F5F5F5" : "#1a1a1a";
    }

    public static string GetPanelBackgroundColor()
    {
        return CurrentTheme == "light" ? "#E8E8E8" : "#34495E";
    }

    public static string GetBorderColor()
    {
        return CurrentTheme == "light" ? "#CCCCCC" : "#1C1C2E";
    }
}
