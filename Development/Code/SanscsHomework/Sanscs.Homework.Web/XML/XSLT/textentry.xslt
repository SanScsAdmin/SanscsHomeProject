<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:template match="/">
    <div class="question">
        <div>
          <xsl:value-of select="assessmentItem/itemBody/p"/>
        </div>
        <xsl:for-each select="assessmentItem/itemBody/blockquote/p/node()">
          <xsl:value-of select="." />
          <xsl:if test="name()='textEntryInteraction'">
            <input type="text" />
          </xsl:if>
          </xsl:for-each>
    <input type="button" onclick="getanswer(this)" value="提交答案">
      <xsl:attribute name="id">
        <xsl:value-of select="/assessmentItem/@questionId"/>
      </xsl:attribute>
    </input>
    </div>
  </xsl:template>
</xsl:stylesheet>

