import React, { useState, useEffect } from 'react';
import * as signalR from '@microsoft/signalr';
import './liveSupport.css';

// ChatButton bileşeni
const ChatButton = ({ toggleChat }) => {
    return (
        <button className="chat-button" onClick={toggleChat}>
            Canlı Destek
        </button>
    );
};

// ChatBox bileşeni
const ChatBox = ({ isOpen, sendMessage, messages, connectionStatus }) => {
    const [message, setMessage] = useState('');

    if (!isOpen) return null;

    return (
        <div className="chat-box">
            <div className="chat-header">
                <span>Canlı Destek - {connectionStatus}</span>
                <button>X</button> {/* Butonun ChatBox u kapatması işlevi eklenecek. */}
            </div>
            <div className="chat-body">
                {messages.map((msg, index) => (
                    <div key={index} className="chat-message">
                        {msg}
                    </div>
                ))}
            </div>
            <div className="chat-footer">
                <input
                    type="text"
                    value={message}
                    onChange={(e) => setMessage(e.target.value)}
                    placeholder="Mesajınızı yazın..."
                />
                <button className={message.trim() === '' ? '' : 'filled'} onClick={() => sendMessage(message)}>Gönder</button>
            </div>
        </div>
    );
};

// Ana Canlı Destek Bileşeni
const LiveSupport = () => {
    const [isOpen, setIsOpen] = useState(false);
    const [messages, setMessages] = useState([]);
    const [connection, setConnection] = useState(null);
    const [connectionStatus, setConnectionStatus] = useState('Bağlantı Yok');

    useEffect(() => {
        const newConnection = new signalR.HubConnectionBuilder().withAutomaticReconnect([1000, 2000, 3000, 4000])
            .withUrl("https://localhost:44390/LiveSupportHub").build();
        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    console.log('Connected to SignalR Hub!');
                    setConnectionStatus('Bağlandı');
                    connection.on('ReceiveMessage', (message) => {
                        const formattedMessage = `Temsilci: ${message}`;
                        setMessages((prevMessages) => [...prevMessages, formattedMessage]);
                    });
                })
                .catch((error) => {
                    console.error('Connection failed: ', error);
                    setConnectionStatus('Bağlantı Başarısız');
                });

            connection.onreconnecting((err) => {
                console.log('Reconnecting...', err);
                setConnectionStatus('Yeniden Bağlanıyor...');
            });

            connection.onreconnected((connectionId) => {
                console.log('Reconnected, connectionId: ' + connectionId);
                setConnectionStatus('Yeniden Bağlandı');
            });

            connection.onclose(() => {
                console.log('Connection closed.');
                setConnectionStatus('Bağlantı Koptu');
                setTimeout(() => connection.start(), 5000); // Otomatik olarak tekrar bağlanmaya çalışır.
            });
        }
    }, [connection]);

    const toggleChat = () => {
        setIsOpen(!isOpen);
    };

    const sendMessage = (message) => {
        if (connection && connection.state === 'Connected') {
            connection.invoke('SendMessage', message).catch((error) =>
                console.error('Error sending message: ', error)
            );
        }
        setMessages((prevMessages) => [...prevMessages, `You: ${message}`]);
    };

    return (
        <div>
            <ChatButton toggleChat={toggleChat} />
            <ChatBox isOpen={isOpen} sendMessage={sendMessage} messages={messages} connectionStatus={connectionStatus} />
        </div>
    );
};

export default LiveSupport;
