pipeline {
    agent any
    triggers {
        pollSCM('1 * * * *')
        //cron('10 * * * *')
    }
    stages {
        stage('Setup') {
            steps {
                dir("Backend/Test"){
                    sh "rm -rf TestResults"
                }
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet restore Backend/API/API.csproj'
                sh 'dotnet build Backend/API/API.csproj'
                echo 'build complete'
            }
        }
        stage('Test') {
            steps {
                dir("Backend/Test"){
                    sh "dotnet add package coverlet.collector"
                    sh "mkdir TestResults"
                    sh "dotnet test --collect:'XPlat Code Coverage'"
                    sh "ls -R TestResults"
                }
               
            }
            post {
                success{
                    archiveArtifacts "Backend/Test/TestResults/**/coverage.cubertura.xml"
                    publishCoverage adapters: [istandbulCoberturaAdapter(path: 'Backend/Test/TestResults/**/coverage.cubertura.xml', thresholds:
                    [[failUnhealthy: true, threshodTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], checksName: '',
                    sourceFileResolver: sourceFiles('NEVER STORE')
                }
            }
        }
        stage('Deploy') {
            steps {
                //
                echo 'deploy'
            }
        }
    }
}