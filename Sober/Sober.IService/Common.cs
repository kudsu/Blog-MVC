using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sober.IService
{
    public class Common
    {
        /// <summary>
        /// 获取Object指定的属性值
        /// </summary>
        /// <param name="info">object对象</param>
        /// <param name="field">属性名称</param>
        /// <returns></returns>
        public object GetPropertyValue(object info, string field)
        {
            if (info == null) return null;
            Type t = info.GetType();
            IEnumerable<System.Reflection.PropertyInfo> property = from pi in t.GetProperties() where pi.Name.ToLower() == field.ToLower() select pi;
            return property.First().GetValue(info, null);
        }
        /// <summary>
        /// BlowFish加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string BlowFishEncryption(string value)
        {
            BlowFish algo = new BlowFish();
            string encryptedTxt = algo.Encrypt_CBC(value);
            return encryptedTxt;
        }
        /// <summary>
        /// BlowFish解密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string BlowFishDecrypt(string value)
        {
            BlowFish algo = new BlowFish();
            string decryptedTxt = algo.Decrypt_CBC(value);
            return decryptedTxt;
        }
    }
}
