using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRTelegramBot;
using PRTelegramBot.Attributes;
using PRTelegramBot.Models;
using PRTelegramBot.Utils;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Reflection.Metadata;
using PRTelegramBot.Helpers;
using static System.Net.WebRequestMethods;
using Microsoft.VisualBasic.FileIO;
using Microsoft.EntityFrameworkCore;
using SPO_2_telegram_bot;
using System.Security.Cryptography.X509Certificates;



namespace SPO_2_telegram_bot.Data
{
    public class Commands
    {

        // запуск бота
        [ReplyMenuDictionaryHandler("/start")]
        public static async Task Start(ITelegramBotClient botClient, Update update)
        {
            var message5 = "Бот успешно запущен; для успешного выполнения всех функций - пропишите команду /reg";
            var SendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message5);
        }
        // Команда для проверки работоспособности бота
        [ReplyMenuHandler("Тест")]
        public static async Task Example(ITelegramBotClient botClient, Update update)
        {
            var message = "Hello world";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
        }
        [ReplyMenuDictionaryHandler("/reg")]
        public static async Task Registration(ITelegramBotClient botClient, Update update)
         {

             var message6 = "Пользователь зарегистрирован";
             var SendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message6); 

         }
        // вывод доступных команд у бота

        [ReplyMenuDictionaryHandler("/help")]
        public static async Task ShowCommands(ITelegramBotClient botClient, Update update)
        {
            var message2 = $"Основные команды:\r\n\r\n/help - меню доступных основных команд\r\n\r\n/menu - выбор магазина(Магнит, Пятерочка, Спар)\r\n\r\n/bonus - бонусы, накопленные за пройденное расстояние\r\n";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message2);
        }
        [ReplyMenuDictionaryHandler("/getloc")]
        public static async Task GetLocation(ITelegramBotClient botClient, Update update)
        {
            var Location = $"Предоставьте нам свою геолокацию:";
            var ShopList = new List<KeyboardButton>();
            var ShopListString = new List<string>();
            ShopList.Add(new KeyboardButton($"\r\n\r\nHome"));
            ShopList.Add(new KeyboardButton($"\r\n\r\nNothing"));
            ShopList.Add(new KeyboardButton($"\r\n\r\nNothing"));

            var menu2 = MenuGenerator.ReplyKeyboard(1, ShopList);
            var option2 = new OptionMessage
            {
                MenuReplyKeyboardMarkup = menu2
            };
            var SendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, Location, option2);
        }
        [ReplyMenuHandler("Home")]
        public static async Task Home(ITelegramBotClient botClient, Update update)
        {
            var Home = "Обратитесь к команде /menu, чтобы продолжить пользоваться ботом";
            var SendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, Home);
        }
        // вывод меню для выбора магазина
        [ReplyMenuDictionaryHandler("/menu")]
        public static async Task ShowMenu(ITelegramBotClient botClient, Update update)
        {
            var message3 = "Выберите магазин: ";

            var menuList = new List<KeyboardButton>();
            var menuListString = new List<string>();

            menuList.Add(new KeyboardButton("Пятёрочка"));
            menuList.Add(new KeyboardButton("FIX-Price"));
            menuList.Add(new KeyboardButton("Спар"));

            var menu = MenuGenerator.ReplyKeyboard(1, menuList);

            var option = new OptionMessage
            {
                MenuReplyKeyboardMarkup = menu
            };

            var SendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message3, option);


        }
        // Возможность показать кол-во бонусов пользователя
        [ReplyMenuDictionaryHandler("/bonus")]
        public static async Task ShowBonus(ITelegramBotClient botClient, Update update)
        {
            var message4 = "Ваше кол-во бонусов:";
            var SendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message4);
        }
        // Если пользователь выбрал FIX-PRICE
        [ReplyMenuDictionaryHandler("FIX-PRICE")]
        public static async Task showShop(ITelegramBotClient botClient, Update update)
        {
            var message6 = "В какой ближайший магазин вы хотите пойти: ";
            var ShopList = new List<KeyboardButton>();
            var ShopListString = new List<string>();
            ShopList.Add(new KeyboardButton($"\r\n\r\nУлица Митино"));
            ShopList.Add(new KeyboardButton($"\r\n\r\nУлица Баярышная"));
            ShopList.Add(new KeyboardButton($"\r\n\r\nУлица Малые Сады"));

            var menu2 = MenuGenerator.ReplyKeyboard(1, ShopList);
            var option2 = new OptionMessage
            {
                MenuReplyKeyboardMarkup = menu2
            };
            var SendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message6, option2);
        }
        // Если пользователь выбрал Магнит
        [ReplyMenuDictionaryHandler("Магнит")]

        public static async Task showShop1(ITelegramBotClient botClient, Update update)
        {
            var message6 = "В какой ближайший магазин вы хотите пойти: ";
            var ShopList = new List<KeyboardButton>();
            var ShopListString = new List<string>();
            ShopList.Add(new KeyboardButton($"\r\n\r\nУлица Митино"));
            ShopList.Add(new KeyboardButton($"\r\n\r\nУлица Барышиха"));
            ShopList.Add(new KeyboardButton($"\r\n\r\nУлица Малые Сады"));

            var menu2 = MenuGenerator.ReplyKeyboard(1, ShopList);
            var option3 = new OptionMessage
            {
                MenuReplyKeyboardMarkup = menu2
            };
            var SendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message6, option3);
        }
        // Если пользователь выбрал Спар
        [ReplyMenuDictionaryHandler("Спар")]

        public static async Task showShop2(ITelegramBotClient botClient, Update update)
        {
            var message6 = "В какой ближайший магазин вы хотите пойти: ";
            var ShopList = new List<KeyboardButton>();
            var ShopListString = new List<string>();
            ShopList.Add(new KeyboardButton($"\r\n\r\nУлица Митино"));
            ShopList.Add(new KeyboardButton($"\r\n\r\nУлица Барышиха"));
            ShopList.Add(new KeyboardButton($"\r\n\r\nУлица Малые Сады"));

            var menu2 = MenuGenerator.ReplyKeyboard(1, ShopList);
            var option4 = new OptionMessage
            {
                MenuReplyKeyboardMarkup = menu2
            };
            var SendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message6, option4);
        }
            /*        public class YandexMapsAPI
                    {
                        private string apiKey = "67ffba5f-a0a9-4433-9d2d-2ce27c8d08fc";
                        private HttpClient client;

                        public YandexMapsAPI()
                        {
                            client = new HttpClient();
                            client.BaseAddress = new Uri("https://api-maps.yandex.ru");
                        }

                        public static async Task<string> GetLocationInfo(double latitude, double longitude)
                        {

                            string endpoint = $"/geocoder/v1/?apikey=67ffba5f-a0a9-4433-9d2d-2ce27c8d08fc&format=json&lang=en_US&kind=locality&geocode={latitude},{longitude}";

                            var client = new HttpClient();

                            HttpResponseMessage response = await client.GetAsync(endpoint);
                            if (response.IsSuccessStatusCode)
                            {
                                string responseBody = await response.Content.ReadAsStringAsync();
                                return responseBody;
                            }

                            return string.Empty;
                        }
                        [ReplyMenuDictionaryHandler("/getlocation")]
                        public async void OnMessageReceived(object sender, Telegram.Bot.Requests.MessageEventArgs e)
                        {

                            string[] coordinates = e.Message.Text.Split(' ');
                            if (coordinates.Length == 3)
                            {
                                double latitude = double.Parse(coordinates[1]);
                                double longitude = double.Parse(coordinates[2]);

                                YandexMapsAPI yandexMapsAPI = new YandexMapsAPI();
                                string locationInfo = await yandexMapsAPI.GetLocationInfo(latitude, longitude);

                                var SendMessage = await PRTelegramBot.Helpers.Message.Send(e.Message.Chat.Id, locationInfo);
                            }
                            else
                            {
                                var SendMessage = await PRTelegramBot.Helpers.Message.Send(e.Message.Chat.Id, "Invalid command. Use '/getlocation latitude longitude'.");
                            }

                        }
                    }*/
        }
    }
}



