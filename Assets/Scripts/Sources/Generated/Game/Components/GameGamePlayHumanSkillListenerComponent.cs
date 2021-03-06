//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GamePlayHumanSkillListenerComponent gamePlayHumanSkillListener { get { return (GamePlayHumanSkillListenerComponent)GetComponent(GameComponentsLookup.GamePlayHumanSkillListener); } }
    public bool hasGamePlayHumanSkillListener { get { return HasComponent(GameComponentsLookup.GamePlayHumanSkillListener); } }

    public void AddGamePlayHumanSkillListener(System.Collections.Generic.List<IGamePlayHumanSkillListener> newValue) {
        var index = GameComponentsLookup.GamePlayHumanSkillListener;
        var component = (GamePlayHumanSkillListenerComponent)CreateComponent(index, typeof(GamePlayHumanSkillListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGamePlayHumanSkillListener(System.Collections.Generic.List<IGamePlayHumanSkillListener> newValue) {
        var index = GameComponentsLookup.GamePlayHumanSkillListener;
        var component = (GamePlayHumanSkillListenerComponent)CreateComponent(index, typeof(GamePlayHumanSkillListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGamePlayHumanSkillListener() {
        RemoveComponent(GameComponentsLookup.GamePlayHumanSkillListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGamePlayHumanSkillListener;

    public static Entitas.IMatcher<GameEntity> GamePlayHumanSkillListener {
        get {
            if (_matcherGamePlayHumanSkillListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GamePlayHumanSkillListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGamePlayHumanSkillListener = matcher;
            }

            return _matcherGamePlayHumanSkillListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddGamePlayHumanSkillListener(IGamePlayHumanSkillListener value) {
        var listeners = hasGamePlayHumanSkillListener
            ? gamePlayHumanSkillListener.value
            : new System.Collections.Generic.List<IGamePlayHumanSkillListener>();
        listeners.Add(value);
        ReplaceGamePlayHumanSkillListener(listeners);
    }

    public void RemoveGamePlayHumanSkillListener(IGamePlayHumanSkillListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gamePlayHumanSkillListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGamePlayHumanSkillListener();
        } else {
            ReplaceGamePlayHumanSkillListener(listeners);
        }
    }
}
