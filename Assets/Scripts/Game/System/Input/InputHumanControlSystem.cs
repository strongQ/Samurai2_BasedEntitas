﻿using System;
using System.Collections.Generic;

namespace Game
{
    /// <summary>
    /// 没有按键按下的状态
    /// </summary>
    public class InputNullSysytem : InputButtonSystemBase
    {
        public InputNullSysytem(Contexts contexts) : base(contexts)
        {
        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.NULL
                && entity.gameInputButton.InputState == InputState.NULL;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            if (_contexts.game.hasGamePlayer)
            {
                _contexts.game.gamePlayer.Ani.Idle();
                _contexts.game.gamePlayer.Ani.IsRun = false;
                _contexts.game.gamePlayer.Audio.IsRun = false;
            }
            _contexts.service.gameServiceTimerService.TimerService.GeTimer(TimerId.MOVE_TIMER)?.Stop(true);
        }
    }

    /// <summary>
    /// 向前按键响应系统
    /// </summary>
    public class InputForwardButtonSystem : InputPressButtonSystemBase
    {
        public InputForwardButtonSystem(Contexts contexts) : base(contexts)
        {
        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.FORWARD;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            _contexts.game.gamePlayer.Behaviour.TurnForward();
            _contexts.game.gamePlayer.Ani.Move();
        }
    }

    /// <summary>
    /// 向后按键响应系统
    /// </summary>
    public class InputBackButtonSystem : InputPressButtonSystemBase
    {
        public InputBackButtonSystem(Contexts contexts) : base(contexts)
        {
        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.BACK;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            _contexts.game.gamePlayer.Behaviour.TurnBack();
            _contexts.game.gamePlayer.Ani.Move();
        }
    }

    /// <summary>
    /// 向左按键响应系统
    /// </summary>
    public class InputLeftButtonSystem : InputPressButtonSystemBase
    {
        public InputLeftButtonSystem(Contexts contexts) : base(contexts)
        {
        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.LEFT;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            _contexts.game.gamePlayer.Behaviour.TurnLeft();
            _contexts.game.gamePlayer.Ani.Move();
        }
    }

    /// <summary>
    /// 向右按键响应系统
    /// </summary>
    public class InputRightButtonSystem : InputPressButtonSystemBase
    {
        public InputRightButtonSystem(Contexts contexts) : base(contexts)
        {
        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.RIGHT;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            _contexts.game.gamePlayer.Behaviour.TurnRight();
            _contexts.game.gamePlayer.Ani.Move();
        }
    }

    /// <summary>
    /// 移动部分响应系统
    /// </summary>
    public class InputMoveButtonSystem : InputDownButtonSystemBase
    {
        public InputMoveButtonSystem(Contexts contexts) : base(contexts)
        {
        }

        protected override bool FilterCondition(InputEntity entity)
        {
            return entity.gameInputButton.InputButton == InputButton.LEFT
                || entity.gameInputButton.InputButton == InputButton.RIGHT
                || entity.gameInputButton.InputButton == InputButton.FORWARD
                || entity.gameInputButton.InputButton == InputButton.BACK;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            var service = _contexts.service.gameServiceTimerService.TimerService;
            var timer = service.CreateTimer(TimerId.MOVE_TIMER, 1, false);
            if (timer != null)
                timer.AddCompleteListener(() =>
                {
                    _contexts.game.gamePlayer.Ani.IsRun = true;
                    _contexts.game.gamePlayer.Audio.IsRun = true;
                }
             );
        }
    }
}
