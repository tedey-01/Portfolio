using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp1
{

    class Program
    {
        public struct Pasport                     //СТРУКТУРА ПРЕДСТАВЛЕНИЯ ИНФОРМАЦИИ В JSON ФАЙЛАХ
        {
            public string post_id, post_content;
        }
        

        static void Main(string[] args)
        {   //ВЫПОЛНЯЕТСЯ ВХОД В ВК 
            IWebDriver Browser;
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://vk.com/");

            IWebElement SearchInput = Browser.FindElement(By.Id("index_email"));
            SearchInput.SendKeys("8928*******");                                    //требуется изменить на реальный логин

            IWebElement SearchInput1 = Browser.FindElement(By.Id("index_pass"));
            SearchInput1.SendKeys("VbasiaPupkin123" + Keys.Enter);                  //требуется изменить на реальный пароль 
            Thread.Sleep(15000);

            List<IWebElement> select = new List<IWebElement>();
            List<Pasport> text = new List<Pasport>();
            List<Pasport> picter = new List<Pasport>();
            List<Pasport> hesh = new List<Pasport>();

            string Idpost, Idpost2, Idpost3;
            IWebElement OldNews = Browser.FindElement(By.Id("show_more_link"));

            IWebElement indicator = null;

            for (int sh = 0; sh < 5; sh++)
            {
                Thread.Sleep(15000);                                                            //остановка потока для обновлениея страницы в ВК 
                
                if (sh != 0) indicator = select.Last();
                select = Browser.FindElements(By.XPath(@".//div[@class ='wall_text']/div")).ToList();
                if (sh > 0)
                {
                    try
                    {
                        int g = 0;
                        while (select[0].GetAttribute("id") != indicator.GetAttribute("id"))
                        {
                            select.RemoveAt(0);
                        }
                        select.RemoveAt(0);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("не удалось удалить Элемент списка" + sh);
                    }
                }

                Find_text1(select, text);
                Find_pmg1(select, picter);
                Find_hesh1(select, hesh);
                
                Thread t1 = new Thread(Write_text1);
                t1.Start();
                Thread t2 = new Thread(Write_pmg1);
                t2.Start();
                Thread t3 = new Thread(Write_hesh1);
                t3.Start();
                
                //ОЖИДАНИЕ ЗАВЕРЩЕНИЯ ЗАПИСИ В ФАЙЛЫ 
                t1.Join();
                t2.Join();
                t3.Join();

                Text_get();
                Console.WriteLine("--------------------------------------------------------------------");
                Pmg_get();
                Console.WriteLine("--------------------------------------------------------------------");
                Hesh_get();
                //myConection.Close();

                OldNews.Click();
            }

            
            //--МЕТОД ПОИСКА  ID НОВОСТЕЙ И ТЕКСТА-----------------------------------------------------------------------------------------
            void Find_text1(List<IWebElement> _select, List<Pasport> _text)
            {
                _text.Clear();
                Pasport pasport1 = new Pasport();
                for (int i = 0; i < _select.Count; i++)
                {
                    try
                    {
                        Idpost = _select[i].GetAttribute("id");
                        Idpost = "post" + Idpost.Remove(0, 3);


                        pasport1.post_id = Idpost;
                        pasport1.post_content = _select[i].Text;

                        _text.Add(pasport1);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Возникла ошибка со считыванием текстом, из-за наличия рекламы ");
                    }

                }
            }

            //--МЕТОД ПОИСКА ID НОВОСТЕЙ И ПУТЕЙ КАРТИНОК----------------------------------------------------------------------------------
            void Find_pmg1(List<IWebElement> _select, List<Pasport> _picter)
            {
                _picter.Clear();
                List<IWebElement> temp = new List<IWebElement>();
                Pasport pasport2 = new Pasport();
                for (int i = 0; i < _select.Count; i++)
                {
                    try
                    {
                        Idpost2 = _select[i].GetAttribute("id");
                        temp = Browser.FindElements(By.CssSelector("#" + Idpost2 + " a")).ToList();
                        Idpost2 = "post" + Idpost2.Remove(0, 3);


                        pasport2.post_id = Idpost2;
                        pasport2.post_content = "";
                        for (int j = 0; j < temp.Count; j++)
                            pasport2.post_content += temp[j].GetAttribute("style");

                        _picter.Add(pasport2);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Возникла ошибка со считыванием адреса картинки, из-за наличия рекламы ");
                    }

                }

            }

            //--МЕТОД ПОИСКА ID НОВОСТЕЙ , ССЫЛОК И ХЕШТЕГОВ --------------------------------------------------------------------------------
            void Find_hesh1(List<IWebElement> _select, List<Pasport> _hesh)
            {
                _hesh.Clear();
                List<IWebElement> temp;
                Pasport pasport3 = new Pasport();
                for (int i = 0; i < _select.Count; i++)
                {
                    try
                    {
                        Idpost3 = _select[i].GetAttribute("id");
                        temp = Browser.FindElements(By.CssSelector("#" + Idpost3 + " a")).ToList();
                        Idpost3 = "post" + Idpost3.Remove(0, 3);
               
                        pasport3.post_id = Idpost3;
                        pasport3.post_content = "";
                        for (int j = 0; j < temp.Count; j++)
                            pasport3.post_content += temp[j].GetAttribute("href");

                        _hesh.Add(pasport3);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Возникла ошибка со считыванием ссылки, из-за наличия рекламы ");
                    }

                }
                File.AppendAllText("Href.json", JsonConvert.SerializeObject(hesh) + Environment.NewLine);
            }




            //МЕТОД ЗАПИСИ В ФАЙЛ "Text.json" ID НОВОСТЕЙ И ТЕКСТА-------------------------------------------------------------------------
            void Write_text1(object _text)
            {
                File.Delete("Text.json");
                File.AppendAllText("Text.json", JsonConvert.SerializeObject(text));
            }

            //--МЕТОД ЗАПИСИ В ФАЙЛ "Pmg.json" ID НОВОСТЕЙ И ПУТЕЙ КАРТИНОК-----------------------------------------------------------------
            void Write_pmg1(object _picter)
            {
                File.Delete("Pmg.json");
                File.AppendAllText("Pmg.json", JsonConvert.SerializeObject(picter));
            }

            //--МЕТОД ЗАПИСИ В ФАЙЛ "Hesh.json" ID НОВОСТЕЙ И ССЫЛОК И ХЕШТЕГОВ -------------------------------------------------------------
            void Write_hesh1(object _hesh)
            {
                File.Delete("Href.json");
                File.AppendAllText("Href.json", JsonConvert.SerializeObject(hesh));
            }

            
            //---МЕТОД СЧИТЫВАЕТ ДАННЫЕ  ИЗ JSON ФАЙЛА "TEXT" И ЗАПИСЫВАЕТ В КОНСОЛЬ --------------------------------------------------------
            void Text_get()
            {
                var get_text = JsonConvert.DeserializeObject<List<Pasport>>(File.ReadAllText("Text.json"));
                foreach (Pasport element in get_text)
                {
                    Console.WriteLine(element.post_id + element.post_content);
                }
            }

            //---МЕТОД СЧИТЫВАЕТ ДАННЫЕ  ИЗ JSON ФАЙЛА "PMG" И ЗАПИСЫВАЕТ В КОНСОЛЬ ---------------------------------------------------------
            void Pmg_get()
            {
                var get_picter = JsonConvert.DeserializeObject<List<Pasport>>(File.ReadAllText("Pmg.json"));

                for (int i = 0; i < get_picter.Count; i++)
                {
                    Console.WriteLine(get_picter[i].post_id + get_picter[i].post_content);
                }

            }

            //---МЕТОД СЧИТЫВАЕТ ДАННЫЕ  ИЗ JSON ФАЙЛА "HESH" И ЗАПИСЫВАЕТ В КОНСОЛЬ --------------------------------------------------------
            void Hesh_get()
            {
                var get_hesh = JsonConvert.DeserializeObject<List<Pasport>>(File.ReadAllText("Href.json"));
                for (int i = 0; i < get_hesh.Count; i++)
                {
                    Console.WriteLine(get_hesh[i].post_id + get_hesh[i].post_content);
                }
            }

            Console.WriteLine("----------------------Программа завершила свою работу-------------------------------------");
            Console.ReadKey();
        }

    }
}
