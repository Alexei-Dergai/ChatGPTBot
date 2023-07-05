using OpenAI_API.Chat;
using OpenAI_API;

OpenAIAPI api = new OpenAIAPI(new APIAuthentication("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"));
Conversation chat = api.Chat.CreateConversation();

while (true)
{
    // ввод сообщения пользователя
    Console.Write("User: ");
    var content = Console.ReadLine();

    // если введенное сообщение имеет длину меньше 1 символа
    // то выходим из цикла и завершаем программу
    if (content is not { Length: > 0 }) break;

    // отправляем запрос
    chat.AppendUserInput(content);

    // получаем данные ответа
    var response = await chat.GetResponseFromChatbotAsync();

    if (string.IsNullOrWhiteSpace(response))
    {
        Console.WriteLine("Response is empty");
        continue;
    }

    Console.WriteLine($"ChatGPT: {response}");
}
