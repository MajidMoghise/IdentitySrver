using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.TokenService
{

    public class Incryptor
    {
        public string GetToken(string strToken)
        {
            string MapToken = GetMapToken(strToken);
            string mapt = MapToken.Substring(3);
            int[] leng = strlenghtArray(strToken, MapToken.Substring(3));
            string h = "";
            string p = "";
            string s = "";
            int indxH = -1;
            int indxP = -1;
            int indxS = -1;
            int lengH = 0;
            int lengP = 0;
            int lengS = 0;

            int last = 0;
            for (int i = 0; i < 3; i++)
            {

                if (MapToken[i] == 'h')
                {
                    lengH = leng[mapt.IndexOf('h')];

                    indxH = mapt.IndexOf('h');
                    if (i == 0)
                    {
                        h = strToken.Substring(21, lengH);
                    }

                    if (i == 1)
                    {
                        h = strToken.Substring(21 + last, lengH);
                    }

                    if (i == 2)
                    {
                        h = strToken.Substring(21 + lengP + lengS);
                    }

                    last = lengH;
                }
                else if (MapToken[i] == 'p')
                {
                    indxP = mapt.IndexOf('p');

                    lengP = leng[mapt.IndexOf('p')];
                    if (i == 0)
                    {
                        p = strToken.Substring(21, lengP);
                    }

                    if (i == 1)
                    {
                        p = strToken.Substring(21 + last, lengP);
                    }

                    if (i == 2)
                    {
                        p = strToken.Substring(21 + lengH + lengS);
                    }

                    last = lengP;
                }
                else if (MapToken[i] == 's')
                {
                    indxS = mapt.IndexOf('s');

                    lengS = leng[mapt.IndexOf('s')];
                    if (i == 0)
                    {
                        s = strToken.Substring(21, lengS);
                    }

                    if (i == 1)
                    {
                        s = strToken.Substring(21 + last, lengP);
                    }

                    if (i == 2)
                    {
                        s = strToken.Substring(21 + lengH + lengP);
                    }

                    last = lengS;
                }
            }

            return h + "." + p + "." + s;
        }


        private string GetMapToken(string strToken)
        {
            string re = "";
            for (int i = 0; i < 6; i++)
            {

                if (Agenthps[0].Contains(strToken[i].ToString()))
                {
                    re += "h";
                }
                else if (Agenthps[1].Contains(strToken[i].ToString()))
                {
                    re += "p";
                }
                else if (Agenthps[2].Contains(strToken[i].ToString()))
                {
                    re += "s";
                }
            }

            return re;
        }
        private int[] strlenghtArray(string strToken, string map)
        {
            int[] leng = new int[3];
            string str = "";
            string[] t1 = new string[3] { "", "", "" };
            for (int k = 0; k < 3; k++)
            {
                int endFor = 6 + (5 * (k + 1));
                int beginFor = 6 + (6 * k);
                for (int i = beginFor; i < endFor; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (Count[j].ToString().Contains(strToken[i]))
                        {
                            t1[k] = t1[k] + strToken[i];
                            str += j.ToString();
                        }
                    }

                }
                leng[k] = Convert.ToInt32(str);
                str = "";
            }
            return leng;
        }

        /// <summary>
        /// this method just for jwt
        /// </summary>
        /// <param name="Token"></param>
        /// <returns>return coding Token For client local storage</returns>
        public string Coding(string strToken)
        {

            string titleArreng = hpsArrange();
            string ss = strtitleArreng;
            string IndexArengMap = hpsArrange();
            string ss2 = strtitleArreng;
            string EncryptTokenN = SplitAndEncrypt(strToken, titleArreng);
            string Lenghs = hpsIndexArreng(h.Length, p.Length, s.Length, IndexArengMap);
            string TotalToken = titleArreng + IndexArengMap + Lenghs + EncryptTokenN;
            return TotalToken;
        }

        private string strtitleArreng = "";
        private string SplitAndEncrypt(string strToken, string titleArreng)
        {
            h = strToken.Remove(strToken.IndexOf("."));
            string payload1sing = strToken.Remove(0, strToken.IndexOf(".") + 1);
            p = payload1sing.Remove(payload1sing.IndexOf("."));
            s = payload1sing.Remove(0, payload1sing.IndexOf(".") + 1);
            string EncryptTokenN = EncrypteToken(h, p, s, titleArreng);
            return EncryptTokenN;

        }
        private string hpsArrange()
        {
            string strHPS = "";
            Random r = new Random();

            int Ih = 0;
            int Is = 0;

            Ih = r.Next(1, 3);
        l:
            Is = r.Next(1, 3);
            if (Is == Ih) { goto l; }
            for (int i = 1; i < 4; i++)
            {
                if (i == Ih)
                {
                    strHPS += hpsAgent("h");
                    strtitleArreng += "h";
                }
                else if (i == Is)
                {
                    strHPS += hpsAgent("s");
                    strtitleArreng += "s";
                }
                else
                {
                    strHPS += hpsAgent("p");
                    strtitleArreng += "p";
                }
            }
            return strHPS;

        }
        private string hpsAgent(string _str)
        {
            Random r = new Random();
            int indx = r.Next(0, 17);
            if (_str == "h")
            {
                return Agenthps[0][indx].ToString();
            }
            else if (_str == "p")
            {

                return Agenthps[1][indx].ToString();

            }
            else
            {

                return Agenthps[2][indx].ToString();
            }
        }
        private string hpsNumberIndex(int indx)
        {
            string str = indx.ToString("00000");
            string strReturn = "";
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                int num = Convert.ToInt32(str[i].ToString());
                int j = r.Next(0, 4);
                strReturn += Count[num][j].ToString();
            }

            return strReturn;
        }
        private string hpsIndexArreng(int Ih, int Ip, int Is, string keyArrayArrengMap)
        {

            string strArrengIndexHps = "";
            for (int i = 0; i < keyArrayArrengMap.Length; i++)
            {
                string str = keyArrayArrengMap[i].ToString();
                if (Agenthps[0].Contains(str))
                { strArrengIndexHps += hpsNumberIndex(Ih); }
                else if (Agenthps[1].Contains(str))
                { strArrengIndexHps += hpsNumberIndex(Ip); }
                else if (Agenthps[2].Contains(str))
                { strArrengIndexHps += hpsNumberIndex(Is); }

            }
            return strArrengIndexHps;
        }
        private string EncrypteToken(string _h, string _p, string _s, string hpsMap)
        {
            string strToken = "";
            for (int i = 0; i < hpsMap.Length; i++)
            {
                string str = hpsMap[i].ToString();
                if (Agenthps[0].Contains(str))
                { strToken += _h; }
                else if (Agenthps[1].Contains(str))
                { strToken += _p; }
                else if (Agenthps[2].Contains(str))
                { strToken += _s; }

            }
            return strToken;

        }

        private string h;
        private string p;
        private string s;
        private readonly string[] Count = new string[10] { "ADtrq", "KfuNi", "BSmpQ", "CMdgw", "YIEWe", "PhROs", "TGFVk", "UaXvl", "JZyxc", "Lbjnz" };
        private readonly string[] Agenthps = new string[3] { "BGIJKLSVZaeilprtvz", "AHcRoWudXMDjxNkYq", "CEbmQwfUgsOFPhynT" };
    }

}
