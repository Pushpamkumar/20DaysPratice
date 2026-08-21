using System;
using System.Text.RegularExpressions;

public class Lab1
{
    public static void Main()
    {
        // ============================================================
        // TODO 1: US ZIP Code
        // ============================================================

        // Matches:
        // 12345
        // 12345-6789
        //
        // \d{5}      -> exactly 5 digits
        // (?:-\d{4})? -> optional hyphen followed by 4 digits
        string zipPattern = @"^\d{5}(?:-\d{4})?$";

        Console.WriteLine("===== ZIP CODE =====");

        Console.WriteLine(
            $"12345: {Regex.IsMatch("12345", zipPattern)}"
        );

        Console.WriteLine(
            $"12345-6789: {Regex.IsMatch("12345-6789", zipPattern)}"
        );

        Console.WriteLine(
            $"1234: {Regex.IsMatch("1234", zipPattern)}"
        );


        // ============================================================
        // TODO 2: Username
        // ============================================================

        // Requirements:
        // - 3 to 16 characters
        // - Only letters, digits and underscore
        // - Must NOT start with a digit
        //
        // [A-Za-z_] -> first character must be a letter or underscore
        // [A-Za-z0-9_]{2,15} -> remaining 2 to 15 characters
        string usernamePattern =
            @"^[A-Za-z_][A-Za-z0-9_]{2,15}$";

        Console.WriteLine();
        Console.WriteLine("===== USERNAME =====");

        Console.WriteLine(
            $"user_1: {Regex.IsMatch("user_1", usernamePattern)}"
        );

        Console.WriteLine(
            $"1user: {Regex.IsMatch("1user", usernamePattern)}"
        );

        Console.WriteLine(
            $"ab: {Regex.IsMatch("ab", usernamePattern)}"
        );


        // ============================================================
        // TODO 3: Hex Color
        // ============================================================

        // # followed by exactly 6 hexadecimal characters.
        // A-F and a-f are both allowed.
        string hexPattern = @"^#[0-9A-Fa-f]{6}$";

        Console.WriteLine();
        Console.WriteLine("===== HEX COLOR =====");

        Console.WriteLine(
            $"#1A2B3C: {Regex.IsMatch("#1A2B3C", hexPattern)}"
        );

        Console.WriteLine(
            $"#GGGGGG: {Regex.IsMatch("#GGGGGG", hexPattern)}"
        );

        Console.WriteLine(
            $"1A2B3C: {Regex.IsMatch("1A2B3C", hexPattern)}"
        );


        // ============================================================
        // TODO 4: Password Strength
        // ============================================================

        // We use multiple Regex.IsMatch checks with && instead of
        // creating one large regex.
        //
        // This approach is easier to understand and maintain.
        //
        // Requirements:
        // - At least 8 characters
        // - At least one digit
        // - At least one uppercase letter

        string passwordPattern = @"^.{8,}$";
        string digitPattern = @"\d";
        string uppercasePattern = @"[A-Z]";

        Console.WriteLine();
        Console.WriteLine("===== PASSWORD =====");

        string password1 = "password";
        string password2 = "Password1";
        string password3 = "pass1";

        bool password1Valid =
            Regex.IsMatch(password1, passwordPattern) &&
            Regex.IsMatch(password1, digitPattern) &&
            Regex.IsMatch(password1, uppercasePattern);

        bool password2Valid =
            Regex.IsMatch(password2, passwordPattern) &&
            Regex.IsMatch(password2, digitPattern) &&
            Regex.IsMatch(password2, uppercasePattern);

        bool password3Valid =
            Regex.IsMatch(password3, passwordPattern) &&
            Regex.IsMatch(password3, digitPattern) &&
            Regex.IsMatch(password3, uppercasePattern);

        Console.WriteLine(
            $"password: {password1Valid}"
        );

        Console.WriteLine(
            $"Password1: {password2Valid}"
        );

        Console.WriteLine(
            $"pass1: {password3Valid}"
        );


        // ============================================================
        // TODO 5: Single-Terminator Sentence
        // ============================================================

        // The sentence:
        // - Can contain letters and spaces
        // - Must end with exactly one '.', '!' or '?'
        // - Cannot contain '.', '!' or '?' anywhere before the end
        //
        // [A-Za-z ]+ -> one or more letters/spaces
        // [.!?]      -> exactly one final punctuation mark
        string sentencePattern = @"^[A-Za-z ]+[.!?]$";

        Console.WriteLine();
        Console.WriteLine("===== SENTENCE =====");

        Console.WriteLine(
            $"Hello there.: " +
            $"{Regex.IsMatch("Hello there.", sentencePattern)}"
        );

        Console.WriteLine(
            $"Wait... : " +
            $"{Regex.IsMatch("Wait...", sentencePattern)}"
        );

        Console.WriteLine(
            $"Really?: " +
            $"{Regex.IsMatch("Really?", sentencePattern)}"
        );
    }
}