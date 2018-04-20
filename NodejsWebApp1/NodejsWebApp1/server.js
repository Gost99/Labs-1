const TelegramBot = require('node-telegram-bot-api');

const sqlite = require('sqlite-sync');
sqlite.connect('library.db');
sqlite.run(`CREATE TABLE IF NOT EXISTS messages(
id  INTEGER PRIMARY KEY AUTOINCREMENT,
 Key TEXT NOT NULL UNIQUE,
 from_id INTEGER NOT NULL,
mesage_id INTEGER NOT NULL );`, function (res) {
        if (res.error)
            throw res.error;
    });
sqlite.insert("messages", {
    key: "hello",
    "test": {
        from_message_id: 382549288,
        message_id: 29,
    }
});
console.log(sqlite.run('SELECT * FROM messages '));
const token = '494436136:AAHN-RaV2YBA6jIrHRZheauI0HgaSB7vv60';
const bot = new TelegramBot(token, { polling: true });
bot.onText(/\/get (.+)/, (msg, match) => {
    const chatId = msg.chat.id;
    const key = match[1]; // the captured "whatever"
    const message = getMessage(key);
    console.log(message);
    if (message.exists) {
        bot.forwardMessage(chatId, message.from_id, message.message_id);
    }
});

bot.on('message', (msg) => {
    const chatId = msg.chat.id;

    // send a message to the chat acknowledging receipt of their message
    bot.sendMessage(chatId, JSON.stringify(msg));
});
function isMessageExists(key) {
    return sqlite.run("SELECT COUNT(*) as cnt FROM messages WHERE 'key' = ?", [key])[0].cnt !== 0;
}
function getMessage(key) {
    const data = sqlite.run(
        "SELECT FROM messages WHERE 'key' = ? LIMIT 1",
        [key]);
    if (data.length = 0) {
        return { exists: false };
    }
    data[0].exists = true;
    return data[0];
}