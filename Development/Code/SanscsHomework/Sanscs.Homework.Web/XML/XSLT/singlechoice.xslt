<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template match="/">
    <div class="question">
        <table border="0">
          <tr bgcolor="#9acd32">
            <th colspan="2">
              <xsl:value-of select="assessmentItem/itemBody/choiceInteraction/prompt"/>
            </th>
          </tr>
          <xsl:for-each select="assessmentItem/itemBody/choiceInteraction/simpleChoice">
            <tr>
              <td>
                <xsl:value-of select="."/>
              </td>
              <td>
                <input type="radio">
                  <xsl:attribute name="value">
                    <xsl:value-of select="./@identifier" />
                  </xsl:attribute>
                  <xsl:attribute name="name">
                    <xsl:value-of select="/assessmentItem/@questionId" />
                  </xsl:attribute>
                </input>
              </td>
            </tr>
            <tr>
            </tr>
          </xsl:for-each>
          <tr>
            <td>
              <input type="button" onclick="getanswer(this)" value="提交答案">
                <xsl:attribute name="id">
                  <xsl:value-of select="/assessmentItem/@questionId"/>
                </xsl:attribute>
              </input>
            </td>
          </tr>
        </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
