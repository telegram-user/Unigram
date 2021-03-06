﻿using Microsoft.Toolkit.Uwp.UI.Lottie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Telegram.Td.Api;
using Unigram.Common;
using Unigram.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Unigram.Controls.Messages.Content
{
    public sealed partial class AnimatedStickerContent : UserControl, IContentWithFile
    {
        private MessageViewModel _message;
        public MessageViewModel Message => _message;

        public AnimatedStickerContent(MessageViewModel message)
        {
            InitializeComponent();
            UpdateMessage(message);
        }

        public void UpdateMessage(MessageViewModel message)
        {
            _message = message;

            var sticker = GetContent(message.Content);
            if (sticker == null)
            {
                return;
            }

            //Background = null;
            //Texture.Source = null;
            //Texture.Constraint = message;

            if (sticker.Thumbnail != null && !sticker.DocumentValue.Local.IsDownloadingCompleted)
            {
                UpdateThumbnail(message, sticker.Thumbnail.Photo);
            }

            UpdateFile(message, sticker.DocumentValue);
        }

        public void UpdateMessageContentOpened(MessageViewModel message) { }

        public async void UpdateFile(MessageViewModel message, File file)
        {
            var sticker = GetContent(message.Content);
            if (sticker == null)
            {
                return;
            }

            if (sticker.Thumbnail != null && sticker.Thumbnail.Photo.Id == file.Id)
            {
                UpdateThumbnail(message, file);
                return;
            }
            else if (sticker.DocumentValue.Id != file.Id)
            {
                return;
            }

            if (file.Local.IsDownloadingCompleted)
            {
                //Texture.Source = await PlaceholderHelper.GetWebpAsync(file.Local.Path);
                //Player.Source = LottieVisualSource.CreateFromString("file:///" + file.Local.Path); // new LottieVisualSource { UriSource = new Uri("file:///" + file.Local.Path) };

                try
                {
                    var storage = await StorageFile.GetFileFromPathAsync(file.Local.Path);
                    var source = new LottieVisualSource();

                    Player.Source = source;

                    await source.SetSourceAsync(storage);
                }
                catch
                {
                    // For some reason LottieVisualSource throws an exception on unsupported OS versions
                }

            }
            else if (file.Local.CanBeDownloaded && !file.Local.IsDownloadingActive)
            {
                message.ProtoService.DownloadFile(file.Id, 1);
            }
        }

        private async void UpdateThumbnail(MessageViewModel message, File file)
        {
            if (file.Local.IsDownloadingCompleted)
            {
                Background = new ImageBrush { ImageSource = await PlaceholderHelper.GetWebpAsync(file.Local.Path) };
            }
            else if (file.Local.CanBeDownloaded && !file.Local.IsDownloadingActive)
            {
                message.ProtoService.DownloadFile(file.Id, 1);
            }
        }

        public bool IsValid(MessageContent content, bool primary)
        {
            if (content is MessageDocument document)
            {
                return document.Document.FileName.StartsWith("tg_secret_sticker") && document.Document.FileName.EndsWith("json");
            }
            else if (content is MessageText text && text.WebPage != null && !primary)
            {
                return text.WebPage.Document != null && text.WebPage.Document.FileName.StartsWith("tg_secret_sticker") && text.WebPage.Document.FileName.EndsWith("json");
            }

            return false;
        }

        private Document GetContent(MessageContent content)
        {
            if (content is MessageDocument sticker)
            {
                return sticker.Document;
            }
            else if (content is MessageText text && text.WebPage != null)
            {
                return text.WebPage.Document;
            }

            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var sticker = GetContent(_message.Content);
            //if (sticker == null)
            //{
            //    return;
            //}

            //_message.Delegate.OpenSticker(sticker);
        }
    }
}
