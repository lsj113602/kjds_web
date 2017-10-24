using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLKJDS.Entity
{
    /// <summary>
    /// 所有实体模型必须直接或间接继承此类，T4模板中反射 dll 时将只识别此类的派生类为实体模型
    /// </summary>
    public abstract class EntityModelBaseForReflection
    {
    }
}
