# ちょうぜつ FizzBuzz Enterprise Edition

## これは何？

[ちょうぜつソフトウェア設計入門](https://gihyo.jp/book/2022/978-4-297-13234-7) で取り上げられたサンプルコードの派生版です。  
書籍に掲載されているPHPのコードをC#で書き直しました。

中身は[FizzBuzz](https://ja.wikipedia.org/wiki/Fizz_Buzz)をクリーンアーキテクチャで書き直したものです。

## プロジェクト構成

- [FizzBuzz.Application](/FizzBuzz.Application/): アプリケーションの本体
- [FizzBuzz.Domain](/FizzBuzz.Domain/): ロジックを記述するドメイン層
- [FizzBuzz.Tests](/FizzBuzz.Tests/): テストコード

## つかいかた

利用前にDI (依存性注入) で設定します。  
.NET標準のDIコンテナを使う場合、`IServiceCollection` のサービスプロバイダに対して以下のように設定してください。

```cs
// 3の倍数の場合はFizz、5の倍数の場合はBuzz、15の倍数の場合はFizzBuzz、それ以外の場合は数字をそのまま表示
services
    .AddFizzBuzz(
        new CyclicNumberRule(3, "Fizz"),
        new CyclicNumberRule(5, "Buzz"),
        new PassThroughRule()
    );
```

FizzBuzzのルールは自由に組み替えることができます。

```cs
/*
下記の規則でFizzBuzzするように設定する:
- 3の倍数の場合は「ふぃず」
- 5の倍数の場合は「ばず」
- 15の倍数の場合は「ふぃずばず」
- 30の倍数の場合は「ふぃずばず!!」
- それ以外の場合は数字をそのまま表示
*/
services
    .AddFizzBuzz(
        new CyclicNumberRule(3, "ふぃず"),
        new CyclicNumberRule(5, "ばず"),
        new CyclicNumberRule(30, "!!"),
        new PassThroughRule()
    );
```

出力にはDIコンテナから`FizzBuzzSequencePrinter`を利用します。

```cs
public class FizzBuzzPresenter
{
    private readonly FizzBuzzSequencePrinter _fizzBuzz;

    public FizzBuzzPresenter(FizzBuzzSequencePrinter fizzBuzz)
    {
        _fizzBuzz = fizzBuzz;
    }

    public void PrintFizzBuzz1To100()
    {
        // 1-100まで順番にFizzBuzzする
        fizzBuzz.PrintRange(1, 100);
    }
}
```

コンソールアプリでの実際の使用例は [こちら](./FizzBuzz.Application/Program.cs) にあります。

## 感想

- FizzBuzzって何だっけ……
- ガチで仕様変更に強いシステムを作るとなると、やはりなかなか大変ですね
- テスト駆動開発は設計と表裏一体という学びを得た
- ちょうぜつ本はいいぞ！

## 参考

- もっとすごい実装はこちら: <https://github.com/EnterpriseQualityCoding/FizzBuzzEnterpriseEdition>
