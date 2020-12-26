﻿using System;
using System.Collections.Generic;
using CefSharp;
using VampEdit.UI.Layout;
using Newtonsoft.Json;
using VampEdit.API.UI;
using VampEdit.API.UI.Layout;

namespace VampEdit.UI
{
    internal static class CefUI
    {
        internal static List<IElement> CreatedElements { get; } = new List<IElement>();
         
        internal static RuntimeInterface UI { get; } = new RuntimeInterface();

        internal static void SetElementAttribute(string id, string key, string val)
        {
            MainForm.Instance.Browser.ExecuteScriptAsyncWhenPageLoaded(
                $"ui_SetElementAttribute('{id}', '{key}', `{val}`)");
        }

        internal static void SetElementStyle(string id, string key, object val)
        {
            MainForm.Instance.Browser.ExecuteScriptAsyncWhenPageLoaded(
                $"ui_SetElementStyle('{id}', '{key}', `{JsonConvert.SerializeObject(val)}`)");
        }

        internal static void AddCardFooterButton(string id, string clickId, string text, bool isDanger)
        {
            string state = isDanger ? "true" : "false";
            MainForm.Instance.Browser.ExecuteScriptAsyncWhenPageLoaded(
                $"ui_AddCardFooterButton('{id}_card_footer', '{clickId}', '{text}', {state})");
        }

        internal static void SetElementDisplay(string id, bool visible)
        {
            string state = visible ? "true" : "false";
            MainForm.Instance.Browser.ExecuteScriptAsyncWhenPageLoaded(
                $"ui_SetElementDisplay('{id}', {state})");
        }

        internal static void SetInnerHTML(string id, string html)
        {
            MainForm.Instance.Browser.ExecuteScriptAsyncWhenPageLoaded(
                $"ui_SetInnerHTML('{id}', `{html}`)");
        }

        internal static void RemoveElementClass(string id, string clazz)
        {
            MainForm.Instance.Browser.ExecuteScriptAsyncWhenPageLoaded(
                $"ui_RemoveClass('{id}', `{clazz}`)");
        }

        internal static void AddElementClass(string id, string clazz)
        {
            MainForm.Instance.Browser.ExecuteScriptAsyncWhenPageLoaded(
                $"ui_AddClass('{id}', `{clazz}`)");
        }

        internal static void DestroyElement(string id)
        {
            MainForm.Instance.Browser.ExecuteScriptAsyncWhenPageLoaded($"ui_DestroyElement('{id}')");
        }

        internal static void AddElementToParent(string parentId, string html)
        {
            MainForm.Instance.Browser.ExecuteScriptAsyncWhenPageLoaded(
                $"ui_CreateElement('{parentId}', `{html}`)");
        }

        internal static IElement CreateElement<T>(IParent parent, string id, SetupSettings settings) where T : IElement
        {
            Element element = ElementRegistry.CreateElement<T>(parent, id, settings);
            if (element == null)
            {
                return default;
            }

            CreatedElements.Add(element);
            AddElementToParent(parent.ID, element.GetHTML(string.Join(" ", element.Classes)));
            ((Parent) parent).InternalChildren.Add(element);
            return element;
        }

        internal static string GenerateID()
        {
            return Guid.NewGuid().ToString().Replace("-", "") + Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
