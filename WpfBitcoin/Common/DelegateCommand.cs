﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfBitcoin.Common
{
    /// <summary>
    /// デリゲートを受け取るICommandインターフェースの実装
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        public DelegateCommand(Action execute) : this(execute, () => true )
        {

        }

        /// <summary>
        /// コンストラクタ。
        /// コマンドのExecuteメソッドで実行する処理とCanExecuteメソッドで実行する処理を指定して
        /// DelegateCommandのインスタンスを作成します。
        /// </summary>
        /// <param name="execute">Executeメソッドで実行する処理</param>
        /// <param name="canExecute">CanExecuteメソッドで実行する処理</param>
        public DelegateCommand(Action execute,Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// コマンドを実行します。
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute()
        {
            this.execute();
        }

        /// <summary>
        /// ICommand.Executeの明示的な実装。Executeメソッドに処理を委譲する。
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            this.Execute();
        }

        /// <summary>
        /// コマンドが実行可能な状態かどうか問い合わせます。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute()
        {
            return this.canExecute();
        }
        /// <summary>
        /// ICommand.CanExecuteの明示的な実装。CanExecuteメソッドに処理を委譲する。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute();
        }

        /// <summary>
        /// CanExecuteの結果に変更があったことを通知するイベント。
        /// WPFのCommandManagerのRequerySuggestedイベントをラップする形で実装しています。
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


    }
}