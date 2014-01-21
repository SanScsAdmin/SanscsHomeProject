<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h2>Group single choice</h2>
        <table border="0">
          <tr bgcolor="#9acd32">
            <th>
              <xsl:value-of select="assessmentItem/itemBody/p[1]"/>
            </th>
          </tr>
          <xsl:for-each select="assessmentItem/itemBody/choiceInteraction">
            <tr>
              <td>
                <table>
                  <th>
                    <td colspan="2">
                      <xsl:value-of select="prompt"/>
                    </td>
                  </th>
                  <xsl:for-each select="./simpleChoice">
                    <tr>
                      <td>
                        <xsl:value-of select="."/>
                      </td>
                      <td>
                        <input type="radio" name="singlechoice">
                          <xsl:attribute name="value">
                            <xsl:value-of select="./@identifier" />
                          </xsl:attribute>
                        </input>
                      </td>
                    </tr>
                  </xsl:for-each>
                </table>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
