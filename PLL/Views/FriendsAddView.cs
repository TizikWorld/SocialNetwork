using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendsAddView
    {
        UserService userService;
        public FriendsAddView(UserService userService)
        {
            this.userService = userService;
        }

        public void Add(User user)
        {
            var friends = new Friends();

            Console.Write("Введите почтовый адрес для добавления друга: ");
            friends.FriendEmail = Console.ReadLine();
            friends.UserId = user.Id;

            try
            {
                this.userService.AddFriend(friends);

                SuccessMessage.Show("Друг успешно добавлен!");

                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении в друзья!");
            }
        }
    }
}
