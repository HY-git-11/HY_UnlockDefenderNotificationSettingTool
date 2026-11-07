using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace UnlockDefenderNotificationSettingTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Defender 通知设置工具 By_HY（史桓瑜）";
            while (true)
            {
                InitializationNow();
                string input = Console.ReadLine(); // 临时存储用户输入内容
                switch (input)
                {
                    case "0":
                        PrintDivider();
                        Console.WriteLine("输入内容有效，开始执行任务0。");
                        Console.WriteLine("Defender 通知设置工具（UnlockDefenderNotificationSettingTool）");
                        Console.WriteLine("隶属工程方案：《W小工具合集开发项目》（2026年7月21日立项）");
                        Console.WriteLine("开发者：HuanYU");
                        Console.WriteLine("版本：1.0.0.0");
                        Console.WriteLine("完成，按任意键返回。");
                        break;
                    case "1":
                        PrintDivider();
                        Console.WriteLine("输入内容有效，开始执行任务1。");
                        try
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = "rstrui",
                                UseShellExecute = true
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"打开失败：{ex.Message}");
                        }
                        Console.WriteLine("完成，按任意键返回。");
                        break;
                    case "2":
                        PrintDivider();
                        Console.WriteLine("输入内容有效，开始执行任务2。");
                        try
                        {
                            Registry.SetValue("HKEY_CLASSES_ROOT\\AppUserModelId\\Windows.Defender", "ShowInSettings", 1, RegistryValueKind.DWord);
                            Registry.SetValue("HKEY_CLASSES_ROOT\\AppUserModelId\\Windows.Defender.MpUxDlp", "ShowInSettings", 1, RegistryValueKind.DWord);
                            Registry.SetValue("HKEY_CLASSES_ROOT\\AppUserModelId\\Windows.Defender.SecurityCenter", "ShowInSettings", 1, RegistryValueKind.DWord);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"失败：{ex.Message}");
                        }
                        Console.WriteLine("完成，按任意键返回。");
                        break;
                    case "3":
                        PrintDivider();
                        Console.WriteLine("输入内容有效，开始执行任务3。");
                        try
                        {
                            Registry.SetValue("HKEY_CLASSES_ROOT\\AppUserModelId\\Windows.Defender", "ShowInSettings", 0, RegistryValueKind.DWord);
                            Registry.SetValue("HKEY_CLASSES_ROOT\\AppUserModelId\\Windows.Defender.MpUxDlp", "ShowInSettings", 0, RegistryValueKind.DWord);
                            Registry.SetValue("HKEY_CLASSES_ROOT\\AppUserModelId\\Windows.Defender.SecurityCenter", "ShowInSettings", 0, RegistryValueKind.DWord);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"失败：{ex.Message}");
                        }
                        Console.WriteLine("完成，按任意键返回。");
                        break;
                    case "4":
                        PrintDivider();
                        Console.WriteLine("输入内容有效，开始执行任务4。");
                        try
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = "firewall.cpl",
                                UseShellExecute = true
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"打开失败：{ex.Message}");
                        }
                        Console.WriteLine("完成，按任意键返回。");
                        break;
                    case "5":
                        PrintDivider();
                        Console.WriteLine("输入内容有效，开始执行任务5。");
                        try
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = "windowsdefender://settings",
                                UseShellExecute = true
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"失败：{ex.Message}");
                        }
                        Console.WriteLine("完成，按任意键返回。");
                        break;
                    default:
                        Console.WriteLine("输入有误，按任意键返回。");
                        break;

                }
                Console.ReadKey(); // 等待按键，防止窗口立刻关闭
            }
        }


        /// <summary>
        /// 这里用来打印一串分隔符
        /// </summary>
        /// <param name="length"></param>
        static void PrintDivider(int length = 40)
        {
            Console.WriteLine(new string('=', length));
        }


        /// <summary>
        /// 初始化显示信息
        /// </summary>
        static void InitializationNow()
        {
            // 清屏
            Console.Clear();
            // 开始初始化
            Console.WriteLine("欢迎，此工具用于解锁Win10/11的Windows Defender右下角通知关闭权限。");
            Console.WriteLine("此程序会操作系统注册表，建议您备份完整注册表并在专业人员指导下完成操作。");
            PrintDivider();
            Console.WriteLine("下面是【Win10/11 WD通知】相关注册表项状态：");
            // 开始读取注册表
            try
            {
                RegistryKey wdRK_1 = Registry.ClassesRoot.OpenSubKey("AppUserModelId\\Windows.Defender");
                if (wdRK_1 != null)
                {
                    // Console.WriteLine("成功，识别到关键子项1。");
                    int rk_1 = (int)wdRK_1.GetValue("ShowInSettings", 0);
                    if (rk_1 == 0)
                    {
                        OutputWithColor("第一项：NO未解锁。",ConsoleColor.DarkRed);
                    }
                    else if (rk_1 == 1)
                    {
                        OutputWithColor("第一项：YES已解锁。", ConsoleColor.DarkGreen);
                    }
                    else
                    {
                        OutputWithColor("第一项：NO未知键值。", ConsoleColor.DarkRed);
                    }
                }
                else
                {
                    OutputWithColor("第一项：NO不存在。", ConsoleColor.DarkRed);
                }
                RegistryKey wdRK_2 = Registry.ClassesRoot.OpenSubKey("AppUserModelId\\Windows.Defender.MpUxDlp");
                if (wdRK_2 != null)
                {
                    // Console.WriteLine("成功，识别到关键子项2。");
                    int rk_2 = (int)wdRK_2.GetValue("ShowInSettings", 0);
                    if (rk_2 == 0)
                    {
                        OutputWithColor("第二项：NO未解锁。", ConsoleColor.DarkRed);
                    }
                    else if (rk_2 == 1)
                    {
                        OutputWithColor("第二项：YES已解锁。", ConsoleColor.DarkGreen);
                    }
                    else
                    {
                        OutputWithColor("第二项：NO未知键值。", ConsoleColor.DarkRed);
                    }
                }
                else
                {
                    OutputWithColor("第二项：NO不存在。", ConsoleColor.DarkRed);
                }
                RegistryKey wdRK_3 = Registry.ClassesRoot.OpenSubKey("AppUserModelId\\Windows.Defender.SecurityCenter");
                if (wdRK_3 != null)
                {
                    // Console.WriteLine("成功，识别到关键子项3。");
                    int rk_3 = (int)wdRK_3.GetValue("ShowInSettings", 0);
                    if (rk_3 == 0)
                    {
                        OutputWithColor("第三项：NO未解锁。", ConsoleColor.DarkRed);
                    }
                    else if (rk_3 == 1)
                    {
                        OutputWithColor("第三项：YES已解锁。", ConsoleColor.DarkGreen);
                    }
                    else
                    {
                        OutputWithColor("第三项：NO未知键值。", ConsoleColor.DarkRed);
                    }
                }
                else
                {
                    OutputWithColor("第三项：NO不存在。", ConsoleColor.DarkRed);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine($"恭喜，重要注册表键值检查完成。此时：{DateTime.Now.ToString()}");
            PrintDivider();
            OutputWithColor("[0]查看本程序相关信息", ConsoleColor.Blue);
            OutputWithColor("[1]打开系统还原", ConsoleColor.Blue);
            OutputWithColor("[2]解锁WD通知设置选项", ConsoleColor.Blue);
            OutputWithColor("[3]锁定WD通知设置选项（Windows默认）", ConsoleColor.Blue);
            OutputWithColor("[4]打开Windows防火墙选项（控制面板）", ConsoleColor.Blue);
            OutputWithColor("[5]打开Windows Defender设置页面", ConsoleColor.Blue);
            PrintDivider();
            Console.WriteLine("接下来，你可以输入对应的数字来执行特定任务，请输入：");
        }

        static void OutputWithColor(string text,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
