import * as signalR from '@microsoft/signalr';

// SignalR bağlantısını oluştur
const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://yourserver.com/yourhub") // Burada SignalR hub URL'nizi belirtin
    .withAutomaticReconnect()
    .configureLogging(signalR.LogLevel.Information)
    .build();

export default connection;