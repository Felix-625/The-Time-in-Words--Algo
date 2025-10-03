#include <bits/stdc++.h>

using namespace std;

string ltrim(const string &);
string rtrim(const string &);

/*
 * Complete the 'timeInWords' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts following parameters:
 *  1. INTEGER h
 *  2. INTEGER m
 */

string timeInWords(int h, int m) {
    vector<string> numbers = {"zero", "one", "two", "three", "four", "five", "six",
                              "seven", "eight", "nine", "ten", "eleven", "twelve",
                              "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
                              "eighteen", "nineteen", "twenty", "twenty one", "twenty two",
                              "twenty three", "twenty four", "twenty five", "twenty six",
                              "twenty seven", "twenty eight", "twenty nine"};

    if (m == 0) {
        return numbers[h] + " o' clock";
    } else if (m == 15) {
        return "quarter past " + numbers[h];
    } else if (m == 30) {
        return "half past " + numbers[h];
    } else if (m == 45) {
        int nextHour = (h == 12) ? 1 : h + 1;
        return "quarter to " + numbers[nextHour];
    } else if (m < 30) {
        string minuteStr = (m == 1) ? " minute" : " minutes";
        return numbers[m] + minuteStr + " past " + numbers[h];
    } else {
        int minsTo = 60 - m;
        int nextHour = (h == 12) ? 1 : h + 1;
        string minuteStr = (minsTo == 1) ? " minute" : " minutes";
        return numbers[minsTo] + minuteStr + " to " + numbers[nextHour];
    }
}

int main()
{
    ofstream fout(getenv("OUTPUT_PATH"));

    string h_temp;
    getline(cin, h_temp);

    int h = stoi(ltrim(rtrim(h_temp)));

    string m_temp;
    getline(cin, m_temp);

    int m = stoi(ltrim(rtrim(m_temp)));

    string result = timeInWords(h, m);

    fout << result << "\n";

    fout.close();

    return 0;
}

string ltrim(const string &str) {
    string s(str);

    s.erase(
        s.begin(),
        find_if(s.begin(), s.end(), not1(ptr_fun<int, int>(isspace)))
    );

    return s;
}

string rtrim(const string &str) {
    string s(str);

    s.erase(
        find_if(s.rbegin(), s.rend(), not1(ptr_fun<int, int>(isspace))).base(),
        s.end()
    );

    return s;
}
