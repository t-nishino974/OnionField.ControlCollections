// <copyright file="BaseControlCollection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnionField.ControlCollections
{
    /// <summary>
    /// Windows フォームデザイナーでインデックスを割り当て可能なジェネリックコレクションの基本クラスを提供します。
    /// </summary>
    /// <typeparam name="T">コレクション内の要素の型。</typeparam>
    /// <example>
    /// <code>
    /// [ProvideProperty("Index", typeof({適応対象のコントロール}))]
    /// public class {適応対象のコントロール}Collection : BaseControlCollection{適応対象のコントロール}
    /// </code>
    /// </example>
    public partial class BaseControlCollection<T> : Component, IExtenderProvider, IEnumerable<T>
    {
        /// <summary>
        /// オブジェクトとインデックスを関連付けるための内部辞書。
        /// </summary>
        private readonly Dictionary<T, int> inner = new Dictionary<T, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseControlCollection{T}"/> class.
        /// </summary>
        public BaseControlCollection()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// コンテナーに関連付けて、<see cref="BaseControlCollection{T}"/>クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="container"><see cref="BaseControlCollection{T}"/>のこのインスタンスと関連付ける、<see cref="IContainer"/>を実装するオブジェクト。</param>
        public BaseControlCollection(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();
        }

        /// <summary>
        /// 指定したインデックスにある要素を取得します。
        /// </summary>
        /// <param name="index">要素に関連付けられている<see cref="int"/>。</param>
        /// <returns>指定したインデックスに関連付けられているオブジェクト。</returns>
        public T this[int index] => this.inner.First(o => o.Value == index).Key;

        /// <inheritdoc/>
        bool IExtenderProvider.CanExtend(object extendee) => extendee is T;

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.inner.Select(o => o.Key).GetEnumerator();

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => this.inner.Select(o => o.Key).GetEnumerator();

        /// <summary>
        /// 指定したオブジェクトに関連付けられているインデックスを取得します。
        /// 指定したオブジェクトにインデックスが関連付けられていない場合は-1を返します。
        /// </summary>
        /// <param name="control">インデックスの取得条件となるオブジェクト。</param>
        /// <returns>指定したオブジェクトのインデックスを</returns>
        [DefaultValue(-1)]
        [Description("コントロールと関連付けられたキーとなる数値を取得します。")]
        public int GetIndex(T control)
        {
            if (this.inner.ContainsKey(control))
            {
                return this.inner[control];
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 指定したオブジェクトにインデックスを関連付けます。
        /// </summary>
        /// <param name="control">インデックスを関連付けるオブジェクト。</param>
        /// <param name="index">オブジェクトを関連付けるインデックス。負の数値を指定した場合は関連付けされません。</param>
        public void SetIndex(T control, int index)
        {
            if (index < 0)
            {
                if (this.inner.ContainsKey(control))
                {
                    this.inner.Remove(control);
                }
            }
            else if (this.GetIndex(control) != index)
            {
                while (this.inner.ContainsValue(index))
                {
                    index++;
                }

                this.inner[control] = index;
            }
        }
    }
}
