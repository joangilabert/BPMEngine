﻿using Org.Reddragonit.BpmEngine.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Org.Reddragonit.BpmEngine.Elements.Processes.Conditions
{
    [XMLTag("exts", "orCondition")]
    [RequiredAttribute("id")]
    internal class OrCondition : AConditionSet
    {
        public OrCondition(XmlElement elem, XmlPrefixMap map)
            : base(elem, map) { }

        public override bool Evaluate(ProcessVariablesContainer variables)
        {
            bool ret = false;
            if (_Conditions != null)
            {
                foreach (ACondition cond in _Conditions)
                    ret = ret || cond.Evaluate(variables);
            }
            return ret;
        }

        public override bool IsValid(out string err)
        {
            if (Children.Length < 2)
            {
                err = "Not enough child elements found";
                return false;
            }
            return base.IsValid(out err);
        }
    }
}