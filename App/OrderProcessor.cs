using System;

public class OrderProcessor
{
    private static readonly string[] CAT_NAMES =
    {
        "Electronics",
        "Books",
        "Clothing"
    };

    private static readonly int[] CAT_SHIP =
    {
        10,
        0,
        5
    };

    private static readonly string[] PROMO_CODES =
    {
        "SAVE10",
        "TECH15",
        "READ25",
        "WINTER20"
    };

    private static readonly int[] PROMO_DISCOUNT =
    {
        10,
        15,
        25,
        20
    };

    private static readonly string[] PROMO_ELIGIBLE_CATS =
    {
        "Electronics,Books,Clothing",
        "Electronics",
        "Books",
        "Clothing"
    };

    public static void ProcessOrder(string s)
    {
        string[] a = s.Split(' ');
        string c = a[0];

        double t = 0;
        double sh = 0;
        string seen = "";
        int n = 0;

        string[] codes = new string[a.Length];
        int codeCount = 0;

        if (c != "Regular"
                && c != "Member"
                && c != "VIP")
        {
            Console.WriteLine("INVALID CUSTOMER TYPE");
            return;
        }

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i][0] == '+')
            {
                codes[codeCount] = a[i].Substring(1);
                codeCount++;
                continue;
            }

            string[] b = a[i].Split(':');
            string cat = b[0];
            int p = int.Parse(b[1]);
            int q = int.Parse(b[2]);

            int idx = -1;

            for (int j = 0; j < CAT_NAMES.Length; j++)
            {
                if (CAT_NAMES[j] == cat)
                {
                    idx = j;
                }
            }

            if (idx < 0)
            {
                Console.WriteLine("INVALID CATEGORY");
                return;
            }

            if (!("," + seen).Contains("," + cat + ","))
            {
                n++;
            }

            seen = seen + cat + ",";

            sh = sh + CAT_SHIP[idx] * q;
            t = t + p * q;
        }

        int d = 0;

        if (c == "Member")
        {
            d = 10;
        }

        if (c == "VIP")
        {
            d = 20;
        }

        for (int i = 0; i < codeCount; i++)
        {
            int pi = -1;

            for (int j = 0; j < PROMO_CODES.Length; j++)
            {
                if (PROMO_CODES[j] == codes[i])
                {
                    pi = j;
                }
            }

            if (pi < 0)
            {
                Console.WriteLine("INVALID PROMO CODE");
                return;
            }

            bool ok = true;
            string[] sl = seen.Split(',');

            for (int k = 0; k < sl.Length; k++)
            {
                if (sl[k].Length == 0)
                {
                    continue;
                }

                if (!("," + PROMO_ELIGIBLE_CATS[pi] + ",")
                        .Contains("," + sl[k] + ","))
                {
                    ok = false;
                }
            }

            if (ok && PROMO_DISCOUNT[pi] > d)
            {
                d = PROMO_DISCOUNT[pi];
            }
        }

        double total = t - (t * d) / 100;

        if (c != "VIP" && n < 3)
        {
            total = total + sh;
        }

        Console.WriteLine($"Order Total: {total:F2}");
    }
}