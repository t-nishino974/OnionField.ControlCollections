# OnionField.ControlCollections
VB6のコントロール配列のような機能を実装するための基本クラスといくつかのコントロールに対する実装を提供します。
ユーザーは`BaseControlCollection<T>`を継承するだけで、任意のオブジェクトに Index プロパティを追加できます。
## 実装例
```
[ProvideProperty("Index", typeof(CheckBox))]
public class CheckBoxCollection : BaseControlCollection<CheckBox>
{
}
```
このように`BaseControlCollection<T>`を継承すれば、任意のオブジェクトに Index プロパティを追加できます。