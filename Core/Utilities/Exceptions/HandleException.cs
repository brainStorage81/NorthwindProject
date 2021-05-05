using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Core.Utilities.Exceptions

{   //It was created for the console trials.
    public static class HandleException
    {
        public static void ClassException(Action action)
        {
            var isSuccess = true;
            try
            {
                action.Invoke();
            }
           
            catch (DbUpdateException)
            {
                isSuccess = false;
                //Console.WriteLine("ClassException Başarılı Olmadı!..");
                //Thread.Sleep(2000);
                Console.WriteLine("Hata Mesajı: İşlem Başarısız oldu! Benzer kayıt olabilir veya girmiş olduğunuz bilgiler hatalı olabilir. Lütfen bilgilerinizi kontrol edip tekrar deneyiniz!");
                Thread.Sleep(3000);
                Environment.Exit(0);

            }

            catch (Exception exception)
            {
                isSuccess = false;
                //Console.WriteLine("ClassException Başarılı Olmadı!..");
                //Thread.Sleep(2000);
                Console.WriteLine("Hata Mesajı: " + exception.Message);
                Thread.Sleep(3000);
                Environment.Exit(0);

            }
            finally
            {
                if (isSuccess)
                {
                    Console.WriteLine("Başarıyla Tamamlandı!..");
                }
            }

        }

        public static void AttributeException(Action action)
        {
            var isSuccess = true;
            try
            {
                action.Invoke();
            }

            catch (Exception exception)
            {
                isSuccess = false;
                Console.WriteLine("AttributeException Başarılı Olmadı!..");
                Thread.Sleep(2000);
                Console.WriteLine("Hata Mesajı: " + exception.Message);
                Thread.Sleep(3000);
                Environment.Exit(0);

            }
            finally
            {
                if (isSuccess)
                {
                    Console.WriteLine("Başarıyla Tamamlandı!..");
                }
            }

        }
    }
}
