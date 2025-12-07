# OnionField.ControlCollections
VB6のコントロール配列のような機能を実装するための基本クラスといくつかのコントロールに対する実装を提供します。

## 実装例
```
[ProvideProperty("Index", typeof(CheckBox))]
public class CheckBoxCollection : BaseControlCollection<CheckBox>
{
}
```